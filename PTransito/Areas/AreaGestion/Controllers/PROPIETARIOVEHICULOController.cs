using System;
using System.Collections.Generic;
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
            ModVehiculo mod = new ModVehiculo();

           return View(mod);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(ModVehiculo m)
        {
          //  var pac = await db.PROPIETARIO.Include(p => p.VEHICULO.Select(c=>c.PLACA)).ToListAsync();
            var pac = await db.PROPIETARIO_VEHICULO
                .Include(p => p.VEHICULO)
                .Include(c=>c.PROPIETARIO)
                .Where(c => c.VEHICULO.PLACA == m.PLACA)
                .ToListAsync();

            ModVehiculo mod = new ModVehiculo();
            mod.PROPIETARIO = Convert(pac);
            mod.VEHICULO_ID = ReturnID(pac);
            var propietario = db.PROPIETARIO.AsEnumerable().Select(x => new
            {
                id = x.ID,
                FullName = string.Format("{0} - {1}  ", x.NUMEROIDENTIFICACION, x.NOMBRES)
            }).ToList();

            ViewBag.ID = new SelectList(propietario, "id", "FullName");
            return View(mod);
        }

        private decimal ReturnID(List<PROPIETARIO_VEHICULO> pac)
        {
            foreach (var i in pac)
            {
                return i.VEHICULO.ID;
            }
            return 0;
        }

        private IEnumerable<PROPIETARIO> Convert(List<PROPIETARIO_VEHICULO> pac)
        {
            List<PROPIETARIO> aux = new List<PROPIETARIO>();

            foreach (var i in pac)
            {
                aux.Add(new PROPIETARIO
                {
                    NOMBRES=i.PROPIETARIO.NOMBRES,
                    APELLIDOS=i.PROPIETARIO.APELLIDOS,
                    CORREOELECTRONICO=i.PROPIETARIO.CORREOELECTRONICO,
                    DIRECCION=i.PROPIETARIO.DIRECCION,
                    NUMEROIDENTIFICACION=i.PROPIETARIO.NUMEROIDENTIFICACION,
                    PROPIETARIO_VEHICULO=i.PROPIETARIO.PROPIETARIO_VEHICULO,
                    TELEFONO=i.PROPIETARIO.TELEFONO
                });
            }
                return aux;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Asociar(ModVehiculo m)
        {
            PROPIETARIO_VEHICULO p_V = new PROPIETARIO_VEHICULO();
            p_V.ID_PROPIETARIO = m.PROPIETARIO_LIST.ID;
            p_V.ID_VEHICULO = m.VEHICULO_ID;
            p_V.CREA_FECHA = DateTime.Now;

            db.PROPIETARIO_VEHICULO.Add(p_V);
                await db.SaveChangesAsync();

            return RedirectToAction("Index");
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