using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using TransitoModel;
using TransitoModel.ModelAux;

namespace PTransito.Areas.AreaGestion.Controllers
{
    public class FACTURAController : Controller
    {
        private PRUEBA1Entities db = new PRUEBA1Entities();

        public async Task<ActionResult> Index()
        {
            var fACTURA = db.FACTURA.Include(f => f.VEHICULO);
            return View(await fACTURA.ToListAsync());
        }

        public async Task<ActionResult> Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACTURA fACTURA = await db.FACTURA.FindAsync(id);
            if (fACTURA == null)
            {
                return HttpNotFound();
            }
            return View(fACTURA);
        }

        public ActionResult Create()
        {
            ViewBag.contador = 0;
            ViewBag.ID_VEHICULO = new SelectList(db.VEHICULO, "ID", "PLACA");
            ViewBag.ID_TRAMITE = new SelectList(db.TRAMITE, "ID", "DESCRIPCION");

            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Buscar(ModFactura m)
        {
            var bus = await db.PROPIETARIO_VEHICULO
                 .Include(x => x.VEHICULO)
                 .Include(x => x.PROPIETARIO)
                 .Where(x => x.PROPIETARIO.NUMEROIDENTIFICACION == m.DOCUMENTO && x.VEHICULO.PLACA == m.PLACA).ToListAsync();
            ViewBag.ID_VEHICULO = new SelectList(db.VEHICULO.Where(x => x.PLACA == m.PLACA), "ID", "PLACA");
            ViewBag.contador = bus.Count();
            ViewBag.ID = new SelectList(db.TRAMITE, "ID", "DESCRIPCION");

            return View("create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ModFactura m)
        {
            if (ModelState.IsValid)
            {
                FACTURA_TRAMITE aux = new FACTURA_TRAMITE();
                aux.ID_TRAMITE = m.TRAMITE.ID;
                FACTURA aux2 = new FACTURA();
                aux2.FACTURA_TRAMITE.Add(aux);
                aux2.FECHA = m.FACTURA.FECHA;
                aux2.ID_VEHICULO = m.FACTURA.ID_VEHICULO;
                aux2.NUMERO =m.FACTURA.NUMERO;
                aux2.OBSERVACIONES = m.FACTURA.OBSERVACIONES;
                db.FACTURA.Add(aux2);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

         //   ViewBag.ID_VEHICULO = new SelectList(db.VEHICULO, "ID", "PLACA", fACTURA.ID_VEHICULO);
            return View();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
