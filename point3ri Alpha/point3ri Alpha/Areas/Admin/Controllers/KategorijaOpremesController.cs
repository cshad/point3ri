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
    public class KategorijaOpremesController : Controller
    {
        private point3ri db = new point3ri();

        // GET: Admin/KategorijaOpremes
        public ActionResult Index()
        {
            return View(db.KategorijaOpremes.ToList());
        }

        // GET: Admin/KategorijaOpremes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KategorijaOpreme kategorijaOpreme = db.KategorijaOpremes.Find(id);
            if (kategorijaOpreme == null)
            {
                return HttpNotFound();
            }
            return View(kategorijaOpreme);
        }

        // GET: Admin/KategorijaOpremes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/KategorijaOpremes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NazivKategorije")] KategorijaOpreme kategorijaOpreme)
        {
            if (ModelState.IsValid)
            {
                db.KategorijaOpremes.Add(kategorijaOpreme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategorijaOpreme);
        }

        // GET: Admin/KategorijaOpremes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KategorijaOpreme kategorijaOpreme = db.KategorijaOpremes.Find(id);
            if (kategorijaOpreme == null)
            {
                return HttpNotFound();
            }
            return View(kategorijaOpreme);
        }

        // POST: Admin/KategorijaOpremes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NazivKategorije")] KategorijaOpreme kategorijaOpreme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kategorijaOpreme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategorijaOpreme);
        }

        // GET: Admin/KategorijaOpremes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KategorijaOpreme kategorijaOpreme = db.KategorijaOpremes.Find(id);
            if (kategorijaOpreme == null)
            {
                return HttpNotFound();
            }
            return View(kategorijaOpreme);
        }

        // POST: Admin/KategorijaOpremes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KategorijaOpreme kategorijaOpreme = db.KategorijaOpremes.Find(id);
            db.KategorijaOpremes.Remove(kategorijaOpreme);
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
