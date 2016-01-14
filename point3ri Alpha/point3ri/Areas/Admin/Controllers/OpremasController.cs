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
    public class OpremasController : Controller
    {
        private MVC_Pringup db = new MVC_Pringup();

        // GET: Admin/Opremas
        public ActionResult Index()
        {
            var opremas = db.Opremas.Include(o => o.KategorijaOpreme).Include(o => o.Prostorija).Include(o => o.VrijemeTermina);
            return View(opremas.ToList());
        }

        // GET: Admin/Opremas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oprema oprema = db.Opremas.Find(id);
            if (oprema == null)
            {
                return HttpNotFound();
            }
            return View(oprema);
        }

        // GET: Admin/Opremas/Create
        public ActionResult Create()
        {
            ViewBag.KategorijaOpremeID = new SelectList(db.KategorijaOpremes, "ID", "NazivKategorije");
            ViewBag.ProstorijaID = new SelectList(db.Prostorijas, "ID", "Naziv");
            ViewBag.VrijemeTerminaID = new SelectList(db.VrijemeTerminas, "ID", "NazivOpreme");
            return View();
        }

        // POST: Admin/Opremas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Naziv,VrijemeTerminaID,KategorijaOpremeID,InventarskiBroj,ProstorijaID")] Oprema oprema)
        {
            if (ModelState.IsValid)
            {
                db.Opremas.Add(oprema);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KategorijaOpremeID = new SelectList(db.KategorijaOpremes, "ID", "NazivKategorije", oprema.KategorijaOpremeID);
            ViewBag.ProstorijaID = new SelectList(db.Prostorijas, "ID", "Naziv", oprema.ProstorijaID);
            ViewBag.VrijemeTerminaID = new SelectList(db.VrijemeTerminas, "ID", "NazivOpreme", oprema.VrijemeTerminaID);
            return View(oprema);
        }

        // GET: Admin/Opremas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oprema oprema = db.Opremas.Find(id);
            if (oprema == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategorijaOpremeID = new SelectList(db.KategorijaOpremes, "ID", "NazivKategorije", oprema.KategorijaOpremeID);
            ViewBag.ProstorijaID = new SelectList(db.Prostorijas, "ID", "Naziv", oprema.ProstorijaID);
            ViewBag.VrijemeTerminaID = new SelectList(db.VrijemeTerminas, "ID", "NazivOpreme", oprema.VrijemeTerminaID);
            return View(oprema);
        }

        // POST: Admin/Opremas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Naziv,VrijemeTerminaID,KategorijaOpremeID,InventarskiBroj,ProstorijaID")] Oprema oprema)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oprema).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategorijaOpremeID = new SelectList(db.KategorijaOpremes, "ID", "NazivKategorije", oprema.KategorijaOpremeID);
            ViewBag.ProstorijaID = new SelectList(db.Prostorijas, "ID", "Naziv", oprema.ProstorijaID);
            ViewBag.VrijemeTerminaID = new SelectList(db.VrijemeTerminas, "ID", "NazivOpreme", oprema.VrijemeTerminaID);
            return View(oprema);
        }

        // GET: Admin/Opremas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oprema oprema = db.Opremas.Find(id);
            if (oprema == null)
            {
                return HttpNotFound();
            }
            return View(oprema);
        }

        // POST: Admin/Opremas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Oprema oprema = db.Opremas.Find(id);
            db.Opremas.Remove(oprema);
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
