using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using point3ri_Alpha_0._51.Models;

namespace point3ri_Alpha_0._51.Areas.Admin.Controllers
{
    public class ProstorijasController : Controller
    {
        private point3ri db = new point3ri();

        // GET: Admin/Prostorijas
        public ActionResult Index()
        {
            return View(db.Prostorijas.ToList());
        }

        // GET: Admin/Prostorijas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prostorija prostorija = db.Prostorijas.Find(id);
            if (prostorija == null)
            {
                return HttpNotFound();
            }
            return View(prostorija);
        }

        // GET: Admin/Prostorijas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Prostorijas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Naziv,Dostupnost")] Prostorija prostorija)
        {
            if (ModelState.IsValid)
            {
                db.Prostorijas.Add(prostorija);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prostorija);
        }

        // GET: Admin/Prostorijas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prostorija prostorija = db.Prostorijas.Find(id);
            if (prostorija == null)
            {
                return HttpNotFound();
            }
            return View(prostorija);
        }

        // POST: Admin/Prostorijas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Naziv,Dostupnost")] Prostorija prostorija)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prostorija).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prostorija);
        }

        // GET: Admin/Prostorijas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prostorija prostorija = db.Prostorijas.Find(id);
            if (prostorija == null)
            {
                return HttpNotFound();
            }
            return View(prostorija);
        }

        // POST: Admin/Prostorijas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prostorija prostorija = db.Prostorijas.Find(id);
            db.Prostorijas.Remove(prostorija);
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
