using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TransitoModel;

namespace PTransito.Areas.AreaGestion.Controllers
{
    public class VEHICULOController : Controller
    {
        private PRUEBA1Entities db = new PRUEBA1Entities();

        // GET: AreaGestion/VEHICULO
        public async Task<ActionResult> Index()
        {
            var vEHICULO = db.VEHICULO.Include(v => v.CLASEVEHICULO).Include(v => v.LINEA).Include(v => v.TIPOSERVICIO);
            return View(await vEHICULO.ToListAsync());
        }

        // GET: AreaGestion/VEHICULO/Details/5
        public async Task<ActionResult> Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VEHICULO vEHICULO = await db.VEHICULO.FindAsync(id);
            if (vEHICULO == null)
            {
                return HttpNotFound();
            }
            return View(vEHICULO);
        }

        // GET: AreaGestion/VEHICULO/Create
        public ActionResult Create()
        {
            ViewBag.ID_CLASE = new SelectList(db.CLASEVEHICULO, "ID", "DESCRIPCION");
            ViewBag.ID_LINEA = new SelectList(db.LINEA, "ID", "DESCRIPCION");
            ViewBag.ID_TIPOSERVICIO = new SelectList(db.TIPOSERVICIO, "ID", "DESCRIPCION");
            return View();
        }

        // POST: AreaGestion/VEHICULO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,PLACA,ID_LINEA,MODELO,NUMEROMOTOR,COLOR,ID_CLASE,ID_TIPOSERVICIO")] VEHICULO vEHICULO)
        {
            if (ModelState.IsValid)
            {
                db.VEHICULO.Add(vEHICULO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CLASE = new SelectList(db.CLASEVEHICULO, "ID", "DESCRIPCION", vEHICULO.ID_CLASE);
            ViewBag.ID_LINEA = new SelectList(db.LINEA, "ID", "DESCRIPCION", vEHICULO.ID_LINEA);
            ViewBag.ID_TIPOSERVICIO = new SelectList(db.TIPOSERVICIO, "ID", "DESCRIPCION", vEHICULO.ID_TIPOSERVICIO);
            return View(vEHICULO);
        }

        // GET: AreaGestion/VEHICULO/Edit/5
        public async Task<ActionResult> Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VEHICULO vEHICULO = await db.VEHICULO.FindAsync(id);
            if (vEHICULO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CLASE = new SelectList(db.CLASEVEHICULO, "ID", "DESCRIPCION", vEHICULO.ID_CLASE);
            ViewBag.ID_LINEA = new SelectList(db.LINEA, "ID", "DESCRIPCION", vEHICULO.ID_LINEA);
            ViewBag.ID_TIPOSERVICIO = new SelectList(db.TIPOSERVICIO, "ID", "DESCRIPCION", vEHICULO.ID_TIPOSERVICIO);
            return View(vEHICULO);
        }

        // POST: AreaGestion/VEHICULO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,PLACA,ID_LINEA,MODELO,NUMEROMOTOR,COLOR,ID_CLASE,ID_TIPOSERVICIO")] VEHICULO vEHICULO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vEHICULO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CLASE = new SelectList(db.CLASEVEHICULO, "ID", "DESCRIPCION", vEHICULO.ID_CLASE);
            ViewBag.ID_LINEA = new SelectList(db.LINEA, "ID", "DESCRIPCION", vEHICULO.ID_LINEA);
            ViewBag.ID_TIPOSERVICIO = new SelectList(db.TIPOSERVICIO, "ID", "DESCRIPCION", vEHICULO.ID_TIPOSERVICIO);
            return View(vEHICULO);
        }

        // GET: AreaGestion/VEHICULO/Delete/5
        public async Task<ActionResult> Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VEHICULO vEHICULO = await db.VEHICULO.FindAsync(id);
            if (vEHICULO == null)
            {
                return HttpNotFound();
            }
            return View(vEHICULO);
        }

        // POST: AreaGestion/VEHICULO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(decimal id)
        {
            VEHICULO vEHICULO = await db.VEHICULO.FindAsync(id);
            db.VEHICULO.Remove(vEHICULO);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
