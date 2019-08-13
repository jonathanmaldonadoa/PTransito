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
    public class CLASEVEHICULOController : Controller
    {
        private PRUEBA1Entities db = new PRUEBA1Entities();

        // GET: AreaConfiguracion/CLASEVEHICULO
        public async Task<ActionResult> Index()
        {
            return View(await db.CLASEVEHICULO.ToListAsync());
        }

        // GET: AreaConfiguracion/CLASEVEHICULO/Details/5
        public async Task<ActionResult> Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASEVEHICULO cLASEVEHICULO = await db.CLASEVEHICULO.FindAsync(id);
            if (cLASEVEHICULO == null)
            {
                return HttpNotFound();
            }
            return View(cLASEVEHICULO);
        }

        // GET: AreaConfiguracion/CLASEVEHICULO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AreaConfiguracion/CLASEVEHICULO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,DESCRIPCION")] CLASEVEHICULO cLASEVEHICULO)
        {
            if (ModelState.IsValid)
            {
                db.CLASEVEHICULO.Add(cLASEVEHICULO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cLASEVEHICULO);
        }

        // GET: AreaConfiguracion/CLASEVEHICULO/Edit/5
        public async Task<ActionResult> Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASEVEHICULO cLASEVEHICULO = await db.CLASEVEHICULO.FindAsync(id);
            if (cLASEVEHICULO == null)
            {
                return HttpNotFound();
            }
            return View(cLASEVEHICULO);
        }

        // POST: AreaConfiguracion/CLASEVEHICULO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,DESCRIPCION")] CLASEVEHICULO cLASEVEHICULO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLASEVEHICULO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cLASEVEHICULO);
        }

        // GET: AreaConfiguracion/CLASEVEHICULO/Delete/5
        public async Task<ActionResult> Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASEVEHICULO cLASEVEHICULO = await db.CLASEVEHICULO.FindAsync(id);
            if (cLASEVEHICULO == null)
            {
                return HttpNotFound();
            }
            return View(cLASEVEHICULO);
        }

        // POST: AreaConfiguracion/CLASEVEHICULO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(decimal id)
        {
            CLASEVEHICULO cLASEVEHICULO = await db.CLASEVEHICULO.FindAsync(id);
            db.CLASEVEHICULO.Remove(cLASEVEHICULO);
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
