using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using point3ri.Models;

namespace point3ri.Areas.Admin.Controllers
{
    public class VrijemeTerminasController : Controller
    {
        private MVC_Pringup db = new MVC_Pringup();

        // GET: Admin/VrijemeTerminas
        public ActionResult Index()
        {
            return View(db.VrijemeTerminas.ToList());
        }

        // GET: Admin/VrijemeTerminas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VrijemeTermina vrijemeTermina = db.VrijemeTerminas.Find(id);
            if (vrijemeTermina == null)
            {
                return HttpNotFound();
            }
            return View(vrijemeTermina);
        }

        // GET: Admin/VrijemeTerminas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/VrijemeTerminas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NazivOpreme,PocetakRadnogVremena,KrajRadnogVremena,VremenskiIntervali")] VrijemeTermina vrijemeTermina)
        {
            if (ModelState.IsValid)
            {
                db.VrijemeTerminas.Add(vrijemeTermina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vrijemeTermina);
        }

        // GET: Admin/VrijemeTerminas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VrijemeTermina vrijemeTermina = db.VrijemeTerminas.Find(id);
            if (vrijemeTermina == null)
            {
                return HttpNotFound();
            }
            return View(vrijemeTermina);
        }

        // POST: Admin/VrijemeTerminas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NazivOpreme,PocetakRadnogVremena,KrajRadnogVremena,VremenskiIntervali")] VrijemeTermina vrijemeTermina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vrijemeTermina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vrijemeTermina);
        }

        // GET: Admin/VrijemeTerminas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VrijemeTermina vrijemeTermina = db.VrijemeTerminas.Find(id);
            if (vrijemeTermina == null)
            {
                return HttpNotFound();
            }
            return View(vrijemeTermina);
        }

        // POST: Admin/VrijemeTerminas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VrijemeTermina vrijemeTermina = db.VrijemeTerminas.Find(id);
            db.VrijemeTerminas.Remove(vrijemeTermina);
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
