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
    public class PROPIETARIOController : Controller
    {
        private PRUEBA1Entities db = new PRUEBA1Entities();

        // GET: AreaGestion/PROPIETARIO
        public async Task<ActionResult> Index()
        {
            return View(await db.PROPIETARIO.ToListAsync());
        }

        // GET: AreaGestion/PROPIETARIO/Details/5
        public async Task<ActionResult> Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROPIETARIO pROPIETARIO = await db.PROPIETARIO.FindAsync(id);
            if (pROPIETARIO == null)
            {
                return HttpNotFound();
            }
            return View(pROPIETARIO);
        }

        // GET: AreaGestion/PROPIETARIO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AreaGestion/PROPIETARIO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,NUMEROIDENTIFICACION,NOMBRES,APELLIDOS,DIRECCION,TELEFONO,CORREOELECTRONICO")] PROPIETARIO pROPIETARIO)
        {
            if (ModelState.IsValid)
            {
                db.PROPIETARIO.Add(pROPIETARIO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pROPIETARIO);
        }

        // GET: AreaGestion/PROPIETARIO/Edit/5
        public async Task<ActionResult> Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROPIETARIO pROPIETARIO = await db.PROPIETARIO.FindAsync(id);
            if (pROPIETARIO == null)
            {
                return HttpNotFound();
            }
            return View(pROPIETARIO);
        }

        // POST: AreaGestion/PROPIETARIO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,NUMEROIDENTIFICACION,NOMBRES,APELLIDOS,DIRECCION,TELEFONO,CORREOELECTRONICO")] PROPIETARIO pROPIETARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pROPIETARIO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pROPIETARIO);
        }

        // GET: AreaGestion/PROPIETARIO/Delete/5
        public async Task<ActionResult> Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROPIETARIO pROPIETARIO = await db.PROPIETARIO.FindAsync(id);
            if (pROPIETARIO == null)
            {
                return HttpNotFound();
            }
            return View(pROPIETARIO);
        }

        // POST: AreaGestion/PROPIETARIO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(decimal id)
        {
            PROPIETARIO pROPIETARIO = await db.PROPIETARIO.FindAsync(id);
            db.PROPIETARIO.Remove(pROPIETARIO);
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
