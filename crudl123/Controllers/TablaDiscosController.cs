using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using crudl123;

namespace crudl123.Controllers
{
    public class TablaDiscosController : Controller
    {
        private StockDiscosEntities db = new StockDiscosEntities();

        // GET: TablaDiscos
        public ActionResult Index()
        {
            return View(db.TablaDiscos.ToList());
        }

        // GET: TablaDiscos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TablaDisco tablaDisco = db.TablaDiscos.Find(id);
            if (tablaDisco == null)
            {
                return HttpNotFound();
            }
            return View(tablaDisco);
        }

        // GET: TablaDiscos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TablaDiscos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,NombreDisco,UnidadesDisponibles")] TablaDisco tablaDisco)
        {
            if (ModelState.IsValid)
            {
                db.TablaDiscos.Add(tablaDisco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tablaDisco);
        }

        // GET: TablaDiscos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TablaDisco tablaDisco = db.TablaDiscos.Find(id);
            if (tablaDisco == null)
            {
                return HttpNotFound();
            }
            return View(tablaDisco);
        }

        // POST: TablaDiscos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,NombreDisco,UnidadesDisponibles")] TablaDisco tablaDisco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tablaDisco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tablaDisco);
        }

        // GET: TablaDiscos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TablaDisco tablaDisco = db.TablaDiscos.Find(id);
            if (tablaDisco == null)
            {
                return HttpNotFound();
            }
            return View(tablaDisco);
        }

        // POST: TablaDiscos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TablaDisco tablaDisco = db.TablaDiscos.Find(id);
            db.TablaDiscos.Remove(tablaDisco);
            db.SaveChanges();
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
