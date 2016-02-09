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
    public class RezervacijasController : Controller
    {
        private point3ri db = new point3ri();

        // GET: Admin/Rezervacijas
        public ActionResult Index()
        {
            var rezervacijas = db.Rezervacijas.Include(r => r.AspNetUser).Include(r => r.DanTermini).Include(r => r.Oprema).Include(r => r.Prostorija);
            return View(rezervacijas.ToList());
        }

        // GET: Admin/Rezervacijas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezervacija rezervacija = db.Rezervacijas.Find(id);
            if (rezervacija == null)
            {
                return HttpNotFound();
            }
            return View(rezervacija);
        }

        // GET: Admin/Rezervacijas/Create
        public ActionResult Create()
        {
            ViewBag.KorisnikID = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.DanTerminiID = new SelectList(db.DanTerminis, "ID", "ID");
            ViewBag.OpremaID = new SelectList(db.Opremas, "ID", "Naziv");
            ViewBag.ProstorijaID = new SelectList(db.Prostorijas, "ID", "Naziv");
            return View();
        }

        // POST: Admin/Rezervacijas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,KorisnikID,DatumRezervacije,DanTerminiID,OpremaID,ProstorijaID,VrijemeRezerviranja,RezervacijaAktivna")] Rezervacija rezervacija)
        {
            if (ModelState.IsValid)
            {
                db.Rezervacijas.Add(rezervacija);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KorisnikID = new SelectList(db.AspNetUsers, "Id", "Email", rezervacija.KorisnikID);
            ViewBag.DanTerminiID = new SelectList(db.DanTerminis, "ID", "ID", rezervacija.DanTerminiID);
            ViewBag.OpremaID = new SelectList(db.Opremas, "ID", "Naziv", rezervacija.OpremaID);
            ViewBag.ProstorijaID = new SelectList(db.Prostorijas, "ID", "Naziv", rezervacija.ProstorijaID);
            return View(rezervacija);
        }

        // GET: Admin/Rezervacijas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezervacija rezervacija = db.Rezervacijas.Find(id);
            if (rezervacija == null)
            {
                return HttpNotFound();
            }
            ViewBag.KorisnikID = new SelectList(db.AspNetUsers, "Id", "Email", rezervacija.KorisnikID);
            ViewBag.DanTerminiID = new SelectList(db.DanTerminis, "ID", "ID", rezervacija.DanTerminiID);
            ViewBag.OpremaID = new SelectList(db.Opremas, "ID", "Naziv", rezervacija.OpremaID);
            ViewBag.ProstorijaID = new SelectList(db.Prostorijas, "ID", "Naziv", rezervacija.ProstorijaID);
            return View(rezervacija);
        }

        // POST: Admin/Rezervacijas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,KorisnikID,DatumRezervacije,DanTerminiID,OpremaID,ProstorijaID,VrijemeRezerviranja,RezervacijaAktivna")] Rezervacija rezervacija)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rezervacija).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KorisnikID = new SelectList(db.AspNetUsers, "Id", "Email", rezervacija.KorisnikID);
            ViewBag.DanTerminiID = new SelectList(db.DanTerminis, "ID", "ID", rezervacija.DanTerminiID);
            ViewBag.OpremaID = new SelectList(db.Opremas, "ID", "Naziv", rezervacija.OpremaID);
            ViewBag.ProstorijaID = new SelectList(db.Prostorijas, "ID", "Naziv", rezervacija.ProstorijaID);
            return View(rezervacija);
        }

        // GET: Admin/Rezervacijas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezervacija rezervacija = db.Rezervacijas.Find(id);
            if (rezervacija == null)
            {
                return HttpNotFound();
            }
            return View(rezervacija);
        }

        // POST: Admin/Rezervacijas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rezervacija rezervacija = db.Rezervacijas.Find(id);
            db.Rezervacijas.Remove(rezervacija);
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
