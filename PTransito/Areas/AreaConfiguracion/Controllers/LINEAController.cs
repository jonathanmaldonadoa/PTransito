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
    public class LINEAController : Controller
    {
        private PRUEBA1Entities db = new PRUEBA1Entities();

        // GET: AreaConfiguracion/LINEA
        public async Task<ActionResult> Index()
        {
            var lINEA = db.LINEA.Include(l => l.MARCA);
            return View(await lINEA.ToListAsync());
        }

        // GET: AreaConfiguracion/LINEA/Details/5
        public async Task<ActionResult> Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LINEA lINEA = await db.LINEA.FindAsync(id);
            if (lINEA == null)
            {
                return HttpNotFound();
            }
            return View(lINEA);
        }

        // GET: AreaConfiguracion/LINEA/Create
        public ActionResult Create()
        {
            ViewBag.ID_MARCA = new SelectList(db.MARCA, "ID", "DESCRIPCION");
            return View();
        }

        // POST: AreaConfiguracion/LINEA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,DESCRIPCION,ID_MARCA")] LINEA lINEA)
        {
            if (ModelState.IsValid)
            {
                db.LINEA.Add(lINEA);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_MARCA = new SelectList(db.MARCA, "ID", "DESCRIPCION", lINEA.ID_MARCA);
            return View(lINEA);
        }

        // GET: AreaConfiguracion/LINEA/Edit/5
        public async Task<ActionResult> Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LINEA lINEA = await db.LINEA.FindAsync(id);
            if (lINEA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_MARCA = new SelectList(db.MARCA, "ID", "DESCRIPCION", lINEA.ID_MARCA);
            return View(lINEA);
        }

        // POST: AreaConfiguracion/LINEA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,DESCRIPCION,ID_MARCA")] LINEA lINEA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lINEA).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID_MARCA = new SelectList(db.MARCA, "ID", "DESCRIPCION", lINEA.ID_MARCA);
            return View(lINEA);
        }

        // GET: AreaConfiguracion/LINEA/Delete/5
        public async Task<ActionResult> Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LINEA lINEA = await db.LINEA.FindAsync(id);
            if (lINEA == null)
            {
                return HttpNotFound();
            }
            return View(lINEA);
        }

        // POST: AreaConfiguracion/LINEA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(decimal id)
        {
            LINEA lINEA = await db.LINEA.FindAsync(id);
            db.LINEA.Remove(lINEA);
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
