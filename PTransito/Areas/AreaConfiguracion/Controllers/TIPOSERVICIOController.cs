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

namespace PTransito.Areas.AreaConfiguracion.Controllers
{
    public class TIPOSERVICIOController : Controller
    {
        private PRUEBA1Entities db = new PRUEBA1Entities();

        // GET: AreaConfiguracion/TIPOSERVICIO
        public async Task<ActionResult> Index()
        {
            return View(await db.TIPOSERVICIO.ToListAsync());
        }

        // GET: AreaConfiguracion/TIPOSERVICIO/Details/5
        public async Task<ActionResult> Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOSERVICIO tIPOSERVICIO = await db.TIPOSERVICIO.FindAsync(id);
            if (tIPOSERVICIO == null)
            {
                return HttpNotFound();
            }
            return View(tIPOSERVICIO);
        }

        // GET: AreaConfiguracion/TIPOSERVICIO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AreaConfiguracion/TIPOSERVICIO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,DESCRIPCION")] TIPOSERVICIO tIPOSERVICIO)
        {
            if (ModelState.IsValid)
            {
                db.TIPOSERVICIO.Add(tIPOSERVICIO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tIPOSERVICIO);
        }

        // GET: AreaConfiguracion/TIPOSERVICIO/Edit/5
        public async Task<ActionResult> Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOSERVICIO tIPOSERVICIO = await db.TIPOSERVICIO.FindAsync(id);
            if (tIPOSERVICIO == null)
            {
                return HttpNotFound();
            }
            return View(tIPOSERVICIO);
        }

        // POST: AreaConfiguracion/TIPOSERVICIO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,DESCRIPCION")] TIPOSERVICIO tIPOSERVICIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPOSERVICIO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tIPOSERVICIO);
        }

        // GET: AreaConfiguracion/TIPOSERVICIO/Delete/5
        public async Task<ActionResult> Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOSERVICIO tIPOSERVICIO = await db.TIPOSERVICIO.FindAsync(id);
            if (tIPOSERVICIO == null)
            {
                return HttpNotFound();
            }
            return View(tIPOSERVICIO);
        }

        // POST: AreaConfiguracion/TIPOSERVICIO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(decimal id)
        {
            TIPOSERVICIO tIPOSERVICIO = await db.TIPOSERVICIO.FindAsync(id);
            db.TIPOSERVICIO.Remove(tIPOSERVICIO);
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
