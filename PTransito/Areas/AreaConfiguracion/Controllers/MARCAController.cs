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
    public class MARCAController : Controller
    {
        private PRUEBA1Entities db = new PRUEBA1Entities();

        // GET: AreaConfiguracion/MARCA
        public async Task<ActionResult> Index()
        {
            return View(await db.MARCA.ToListAsync());
        }

        // GET: AreaConfiguracion/MARCA/Details/5
        public async Task<ActionResult> Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MARCA mARCA = await db.MARCA.FindAsync(id);
            if (mARCA == null)
            {
                return HttpNotFound();
            }
            return View(mARCA);
        }

        // GET: AreaConfiguracion/MARCA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AreaConfiguracion/MARCA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,DESCRIPCION")] MARCA mARCA)
        {
            if (ModelState.IsValid)
            {
                db.MARCA.Add(mARCA);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mARCA);
        }

        // GET: AreaConfiguracion/MARCA/Edit/5
        public async Task<ActionResult> Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MARCA mARCA = await db.MARCA.FindAsync(id);
            if (mARCA == null)
            {
                return HttpNotFound();
            }
            return View(mARCA);
        }

        // POST: AreaConfiguracion/MARCA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,DESCRIPCION")] MARCA mARCA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mARCA).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mARCA);
        }

        // GET: AreaConfiguracion/MARCA/Delete/5
        public async Task<ActionResult> Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MARCA mARCA = await db.MARCA.FindAsync(id);
            if (mARCA == null)
            {
                return HttpNotFound();
            }
            return View(mARCA);
        }

        // POST: AreaConfiguracion/MARCA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(decimal id)
        {
            MARCA mARCA = await db.MARCA.FindAsync(id);
            db.MARCA.Remove(mARCA);
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
