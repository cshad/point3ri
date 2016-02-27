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
    public class PrijavaLosegStanjaOpremesController : Controller
    {
        private point3ri db = new point3ri();

        // GET: Admin/PrijavaLosegStanjaOpremes
        public ActionResult Index()
        {
            var prijavaLosegStanjaOpremes = db.PrijavaLosegStanjaOpremes.Include(p => p.Rezervacija).Where(p => p.Rjeseno != true);
            return View(prijavaLosegStanjaOpremes.ToList());
        }

        // GET: Admin/PrijavaLosegStanjaOpremes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrijavaLosegStanjaOpreme prijavaLosegStanjaOpreme = db.PrijavaLosegStanjaOpremes.Find(id);
            if (prijavaLosegStanjaOpreme == null)
            {
                return HttpNotFound();
            }
            return View(prijavaLosegStanjaOpreme);
        }

        // GET: Admin/PrijavaLosegStanjaOpremes/Create
        public ActionResult Create()
        {
            ViewBag.RezervacijaID = new SelectList(db.Rezervacijas, "ID", "KorisnikID");
            return View();
        }

        // POST: Admin/PrijavaLosegStanjaOpremes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RezervacijaID,PronadenoStanje")] PrijavaLosegStanjaOpreme prijavaLosegStanjaOpreme)
        {
            if (ModelState.IsValid)
            {
                db.PrijavaLosegStanjaOpremes.Add(prijavaLosegStanjaOpreme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RezervacijaID = new SelectList(db.Rezervacijas, "ID", "KorisnikID", prijavaLosegStanjaOpreme.RezervacijaID);
            return View(prijavaLosegStanjaOpreme);
        }

        // GET: Admin/PrijavaLosegStanjaOpremes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrijavaLosegStanjaOpreme prijavaLosegStanjaOpreme = db.PrijavaLosegStanjaOpremes.Find(id);
            if (prijavaLosegStanjaOpreme == null)
            {
                return HttpNotFound();
            }
            ViewBag.RezervacijaID = new SelectList(db.Rezervacijas, "ID", "KorisnikID", prijavaLosegStanjaOpreme.RezervacijaID);
            return View(prijavaLosegStanjaOpreme);
        }

        // POST: Admin/PrijavaLosegStanjaOpremes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RezervacijaID,PronadenoStanje")] PrijavaLosegStanjaOpreme prijavaLosegStanjaOpreme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prijavaLosegStanjaOpreme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RezervacijaID = new SelectList(db.Rezervacijas, "ID", "KorisnikID", prijavaLosegStanjaOpreme.RezervacijaID);
            return View(prijavaLosegStanjaOpreme);
        }

        // GET: Admin/PrijavaLosegStanjaOpremes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrijavaLosegStanjaOpreme prijavaLosegStanjaOpreme = db.PrijavaLosegStanjaOpremes.Find(id);
            if (prijavaLosegStanjaOpreme == null)
            {
                return HttpNotFound();
            }
            return View(prijavaLosegStanjaOpreme);
        }

        // POST: Admin/PrijavaLosegStanjaOpremes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrijavaLosegStanjaOpreme prijavaLosegStanjaOpreme = db.PrijavaLosegStanjaOpremes.Find(id);
            db.PrijavaLosegStanjaOpremes.Remove(prijavaLosegStanjaOpreme);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin/PrijavaLosegStanjaOpremes/Rjeseno
        public ActionResult Rjeseno(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrijavaLosegStanjaOpreme prijavaLosegStanjaOpreme = db.PrijavaLosegStanjaOpremes.Find(id);
            if (prijavaLosegStanjaOpreme == null)
            {
                return HttpNotFound();
            }
            return View(prijavaLosegStanjaOpreme);
        }

        // POST: Admin/PrijavaLosegStanjaOpremes/Rjeseno
        [HttpPost, ActionName("Rjeseno")]
        [ValidateAntiForgeryToken]
        public ActionResult Rjeseno(int id)
        {
            PrijavaLosegStanjaOpreme prijavaLosegStanjaOpreme = db.PrijavaLosegStanjaOpremes.Find(id);
            prijavaLosegStanjaOpreme.Rjeseno = true;
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
