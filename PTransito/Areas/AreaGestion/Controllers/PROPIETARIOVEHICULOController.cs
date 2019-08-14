using System.Threading.Tasks;
using System.Web.Mvc;
using TransitoModel.ModelAux;
using TransitoServicio;

namespace PTransito.Areas.AreaGestion.Controllers
{
    public class PROPIETARIOVEHICULOController : Controller
    {
        private SERVICIOS_ASOCIAR SA = new SERVICIOS_ASOCIAR();

        // GET: AreaGestion/PROPIETARIOVEHICULO
        public ActionResult Index()
        {
            ModVehiculo mod = new ModVehiculo();

            return View(mod);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(ModVehiculo m)
        {
            
            ViewBag.ID = new SelectList(SA.GetPropietario(), "id", "FullName");
            return View(await SA.RetornarLista(m));
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Asociar(ModVehiculo m)
        {
            if (await SA.AddAsociar(m))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}