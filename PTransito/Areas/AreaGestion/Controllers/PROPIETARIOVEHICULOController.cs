using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using TransitoModel;
using TransitoModel.ModelAux;

namespace PTransito.Areas.AreaGestion.Controllers
{
    public class PROPIETARIOVEHICULOController : Controller
    {
        private PRUEBA1Entities db = new PRUEBA1Entities();

        // GET: AreaGestion/PROPIETARIOVEHICULO
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(ModVehiculo m)
        {
            var pac = await db.VEHICULO.Where(p => p.PLACA == m.PLACA).ToListAsync();

            return View();
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