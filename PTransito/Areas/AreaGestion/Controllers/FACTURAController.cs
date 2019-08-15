using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using TransitoModel;
using TransitoModel.ModelAux;
using TransitoServicio;

namespace PTransito.Areas.AreaGestion.Controllers
{
    public class FACTURAController : Controller
    {
        private PRUEBA1Entities db = new PRUEBA1Entities();
        private SERVICIO_FACTURA sf = new SERVICIO_FACTURA();

        public async Task<ActionResult> Index()
        {
            var fACTURA = db.FACTURA.Include(f => f.VEHICULO);
            return View(await fACTURA.ToListAsync());
        }

        public async Task<ActionResult> Details(decimal id)
        {
            var aux = await sf.FacturaDetalle(id);
            if (aux == null)
            {
                return HttpNotFound();
            }
            ViewBag.total = aux.FACTURA_TRAMITE.Sum(x=>x.TRAMITE.VALOR);
            ViewBag.ID = new SelectList(db.TRAMITE, "ID", "DESCRIPCION");
            return View(aux);
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
        public ActionResult Buscar(ModFactura m)
        {
            ViewBag.contador = sf.Contar(m);
            ViewBag.ID_VEHICULO = new SelectList(db.VEHICULO.Where(x => x.PLACA == m.PLACA), "ID", "PLACA");
            ViewBag.ID = new SelectList(db.TRAMITE, "ID", "DESCRIPCION");

            return View("create");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AgregarTramite(ModFactura m)
        {
            if(await sf.AgregarTramite(m))
            {
                ViewBag.ID = new SelectList(db.TRAMITE, "ID", "DESCRIPCION");
                return RedirectToAction("Details", new { id = m.FACTURA.ID });
            }
            else
            {
                ViewBag.ID = new SelectList(db.TRAMITE, "ID", "DESCRIPCION");
                return RedirectToAction("Details", new { id = m.FACTURA.ID });
            }

            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ModFactura m)
        {
            if (ModelState.IsValid)
            {
                decimal aux = await sf.CrearFactura(m);
                if (aux>0)
                    return RedirectToAction("Details", new { id = aux });
            }
            return View("Buscar");
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
