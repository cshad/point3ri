using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using point3ri_Alpha_0._51.Models;
using Microsoft.AspNet.Identity;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace point3ri_Alpha_0._51.Controllers
{
    [Authorize]
    [OutputCache(Duration = 1)]
    public class RezervacijasController : Controller
    {
        private point3ri db = new point3ri();

        // GET: Rezervacijas
        public ActionResult Index()
        {
            var rezervacijas = db.Rezervacijas.Include(r => r.AspNetUser).Include(r => r.DanTermini).Include(r => r.Oprema);
            return View(rezervacijas.ToList());
        }

        public static List<Rezervacija> ListaRezervacija = new List<Rezervacija>();
        public ActionResult RezervacijeIndex()
        {
            ListaRezervacija.Clear();

            string KorisnikID = User.Identity.GetUserId();
            DateTime Danas = DateTime.Today;
            foreach (Rezervacija rezervacija in db.Rezervacijas)
            {
                if (rezervacija.KorisnikID == KorisnikID &&
                    rezervacija.RezervacijaAktivna == true &&
                    rezervacija.DatumRezervacije >= Danas)
                {
                    ListaRezervacija.Add(rezervacija);
                }
            }
            return View(ListaRezervacija);
        }

        // GET: Rezervacijas/Details/5
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

        // GET: Rezervacijas/Create
        public ActionResult Create()
        {
            ViewBag.KorisnikID = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.DanTerminiID = new SelectList(db.DanTerminis, "ID", "Termin");
            ViewBag.OpremaID = new SelectList(db.Opremas, "ID", "Naziv");
            ViewBag.ProstorijaID = new SelectList(db.Prostorijas, "ID", "Naziv");
            return View();
        }

        // Primjer za glavnu
        // POST: Rezervacijas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DanTerminiID,OpremaID,ProstorijaID,Trajanje")] Rezervacija rezervacija, int? TrajanjeID, int? DatumRezervacijeID)
        {
            rezervacija.KorisnikID = User.Identity.GetUserId();
            rezervacija.VrijemeRezerviranja = DateTime.Now;
            rezervacija.RezervacijaAktivna = true;
            rezervacija.DatumRezervacije = dvm.DatumiList[DatumRezervacijeID.Value - 1].DatumiRezervacije;

            if (ModelState.IsValid && TrajanjeID != null)
            {
                var duration = TrajanjeList[TrajanjeID.Value].BrojZauzetihTermina;
                if (duration > 1 && rezervacija.DanTerminiID < 145 - duration)
                {
                    int start = rezervacija.DanTerminiID.Value;
                    for (int i = start; i < start + duration; i++)
                    {
                        db.Rezervacijas.Add(rezervacija);
                        db.SaveChanges();
                        rezervacija.DanTerminiID += 1;
                    }
                }
                else
                {
                    db.Rezervacijas.Add(rezervacija);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            ViewBag.KorisnikID = new SelectList(db.AspNetUsers, "Id", "Email", rezervacija.KorisnikID);
            ViewBag.DanTerminiID = new SelectList(db.DanTerminis, "ID", "ID", rezervacija.DanTerminiID);
            ViewBag.OpremaID = new SelectList(db.Opremas, "ID", "Naziv", rezervacija.OpremaID);
            ViewBag.ProstorijaID = new SelectList(db.Prostorijas, "ID", "Naziv");

            return View(rezervacija);
        }

        // GET: Rezervacijas/CreateRacunala
        public ActionResult CreateRacunala()
        {
            ViewBag.KorisnikID = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.DanTerminiID = new SelectList(db.DanTerminis, "ID", "Termin");
            ViewBag.OpremaID = new SelectList(db.Opremas.Where(o => o.KategorijaOpremeID == 1), "ID", "Naziv");
            ViewBag.ProstorijaID = new SelectList(db.Prostorijas.Where(p => !p.Naziv.Contains("IMP")), "ID", "Naziv");
            return View();
        }

        // POST: Rezervacijas/CreateRacunala
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRacunala([Bind(Include = "DanTerminiID,OpremaID,ProstorijaID,Trajanje")] Rezervacija rezervacija, int? TrajanjeID, int? DatumRezervacijeID)
        {

            rezervacija.KorisnikID = User.Identity.GetUserId();
            rezervacija.VrijemeRezerviranja = DateTime.Now;
            rezervacija.RezervacijaAktivna = true;
            rezervacija.DatumRezervacije = dvm.DatumiList[DatumRezervacijeID.Value - 1].DatumiRezervacije;

            if (ModelState.IsValid && TrajanjeID != null)
            {
                var duration = TrajanjeList[TrajanjeID.Value].BrojZauzetihTermina;
                if (duration > 1 && rezervacija.DanTerminiID < 145 - duration)
                {
                    int start = rezervacija.DanTerminiID.Value;
                    for (int i = start; i < start + duration; i++)
                    {
                        db.Rezervacijas.Add(rezervacija);
                        db.SaveChanges();
                        rezervacija.DanTerminiID += 1;
                    }
                }
                else
                {
                    db.Rezervacijas.Add(rezervacija);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            ViewBag.KorisnikID = new SelectList(db.AspNetUsers, "Id", "Email", rezervacija.KorisnikID);
            ViewBag.DanTerminiID = new SelectList(db.DanTerminis, "ID", "ID", rezervacija.DanTerminiID);
            ViewBag.OpremaID = new SelectList(db.Opremas, "ID", "Naziv", rezervacija.OpremaID);
            ViewBag.ProstorijaID = new SelectList(db.Prostorijas, "ID", "Naziv");

            return View(rezervacija);
        }

        // GET: Rezervacijas/CreateStolovi
        public ActionResult CreateStolovi()
        {
            ViewBag.KorisnikID = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.DanTerminiID = new SelectList(db.DanTerminis, "ID", "Termin");
            ViewBag.OpremaID = new SelectList(db.Opremas.Where(o => o.KategorijaOpremeID == 2), "ID", "Naziv");
            ViewBag.ProstorijaID = new SelectList(db.Prostorijas.Where(p => !p.Naziv.Contains("IMP")), "ID", "Naziv");

            return View();
        }

        // POST: Rezervacijas/CreateStolovi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStolovi([Bind(Include = "DanTerminiID,OpremaID,ProstorijaID,Trajanje")] Rezervacija rezervacija, int? TrajanjeID, int? DatumRezervacijeID)
        {

            rezervacija.KorisnikID = User.Identity.GetUserId();
            rezervacija.VrijemeRezerviranja = DateTime.Now;
            rezervacija.RezervacijaAktivna = true;
            rezervacija.DatumRezervacije = dvm.DatumiList[DatumRezervacijeID.Value - 1].DatumiRezervacije;

            if (ModelState.IsValid && TrajanjeID != null)
            {
                var duration = TrajanjeList[TrajanjeID.Value].BrojZauzetihTermina;
                if (duration > 1 && rezervacija.DanTerminiID < 145 - duration)
                {
                    int start = rezervacija.DanTerminiID.Value;
                    for (int i = start; i < start + duration; i++)
                    {
                        db.Rezervacijas.Add(rezervacija);
                        db.SaveChanges();
                        rezervacija.DanTerminiID += 1;
                    }
                }
                else
                {
                    db.Rezervacijas.Add(rezervacija);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            ViewBag.KorisnikID = new SelectList(db.AspNetUsers, "Id", "Email", rezervacija.KorisnikID);
            ViewBag.DanTerminiID = new SelectList(db.DanTerminis, "ID", "ID", rezervacija.DanTerminiID);
            ViewBag.OpremaID = new SelectList(db.Opremas, "ID", "Naziv", rezervacija.OpremaID);
            ViewBag.ProstorijaID = new SelectList(db.Prostorijas, "ID", "Naziv");

            return View(rezervacija);
        }

        // GET: Rezervacijas/CreatePrinteri
        public ActionResult CreatePrinteri()
        {
            ViewBag.KorisnikID = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.DanTerminiID = new SelectList(db.DanTerminis, "ID", "Termin");
            ViewBag.OpremaID = new SelectList(db.Opremas.Where(o => o.KategorijaOpremeID == 2), "ID", "Naziv");
            ViewBag.ProstorijaID = new SelectList(db.Prostorijas.Where(p => !p.Naziv.Contains("IMP")), "ID", "Naziv");

            return View();
        }

        // POST: Rezervacijas/CreatePrinteri
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePrinteri([Bind(Include = "DanTerminiID,OpremaID,ProstorijaID,Trajanje")] Rezervacija rezervacija, int? TrajanjeID, int? DatumRezervacijeID)
        {

            rezervacija.KorisnikID = User.Identity.GetUserId();
            rezervacija.VrijemeRezerviranja = DateTime.Now;
            rezervacija.RezervacijaAktivna = true;
            rezervacija.DatumRezervacije = dvm.DatumiList[DatumRezervacijeID.Value - 1].DatumiRezervacije;

            if (ModelState.IsValid && TrajanjeID != null)
            {
                var duration = TrajanjeList[TrajanjeID.Value].BrojZauzetihTermina;
                if (duration > 1 && rezervacija.DanTerminiID < 145 - duration)
                {
                    int start = rezervacija.DanTerminiID.Value;
                    for (int i = start; i < start + duration; i++)
                    {
                        db.Rezervacijas.Add(rezervacija);
                        db.SaveChanges();
                        rezervacija.DanTerminiID += 1;
                    }
                }
                else
                {
                    db.Rezervacijas.Add(rezervacija);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            ViewBag.KorisnikID = new SelectList(db.AspNetUsers, "Id", "Email", rezervacija.KorisnikID);
            ViewBag.DanTerminiID = new SelectList(db.DanTerminis, "ID", "ID", rezervacija.DanTerminiID);
            ViewBag.OpremaID = new SelectList(db.Opremas, "ID", "Naziv", rezervacija.OpremaID);
            ViewBag.ProstorijaID = new SelectList(db.Prostorijas, "ID", "Naziv");

            return View(rezervacija);
        }

        // GET: Rezervacijas/Edit/5
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
            return View(rezervacija);
        }

        // POST: Rezervacijas/Edit/5
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
            return View(rezervacija);
        }

        // GET: Rezervacijas/Delete/5
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

        // POST: Rezervacijas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rezervacija rezervacija = db.Rezervacijas.Find(id);
            db.Rezervacijas.Remove(rezervacija);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Rezervacijas/Otkazi
        public ActionResult Otkazi(int? id)
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

        // POST: Rezervacijas/Otkazi
        [HttpPost, ActionName("Otkazi")]
        [ValidateAntiForgeryToken]
        public ActionResult OtkaziPotvrda(int id)
        {
            Rezervacija rezervacija = db.Rezervacijas.Find(id);
            rezervacija.RezervacijaAktivna = false;

            db.SaveChanges();
            return RedirectToAction("RezervacijeIndex");
        }

        // GET: Rezervacijas/PrijavaOpreme
        public ActionResult PrijavaOpreme(int? id)
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

        // POST: Rezervacijas/PrijavaOpreme
        [HttpPost, ActionName("PrijavaOpreme")]
        [ValidateAntiForgeryToken]
        public ActionResult PrijavaOpreme(int id)
        {
            PrijavaLosegStanjaOpreme NovaPrijava = new PrijavaLosegStanjaOpreme();
            NovaPrijava.RezervacijaID = id;
            NovaPrijava.Rjeseno = false;
            db.PrijavaLosegStanjaOpremes.Add(NovaPrijava);

            db.SaveChanges();
            return RedirectToAction("RezervacijeIndex");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public static List<Models.DataModel.DatumiDataModel> Datumi = new List<Models.DataModel.DatumiDataModel>()
        {
            new Models.DataModel.DatumiDataModel
            { ID = 1, DatumiRezervacije = DateTime.Today },
            new Models.DataModel.DatumiDataModel
            { ID = 2, DatumiRezervacije = DateTime.Today.AddDays(1) },
            new Models.DataModel.DatumiDataModel
            { ID = 3, DatumiRezervacije = DateTime.Today.AddDays(2) },
            new Models.DataModel.DatumiDataModel
            { ID = 4, DatumiRezervacije = DateTime.Today.AddDays(3) },
            new Models.DataModel.DatumiDataModel
            { ID = 5, DatumiRezervacije = DateTime.Today.AddDays(4) },
            new Models.DataModel.DatumiDataModel
            { ID = 6, DatumiRezervacije = DateTime.Today.AddDays(5) },
            new Models.DataModel.DatumiDataModel
            { ID = 7, DatumiRezervacije = DateTime.Today.AddDays(6) }
        };

        public static List<Models.DataModel.TrajanjeDataModel> TrajanjeList = new List<Models.DataModel.TrajanjeDataModel>()
        {
            new Models.DataModel.TrajanjeDataModel
            { ID = 0, Trajanje = "5 minuta", BrojZauzetihTermina = 1 },
            new Models.DataModel.TrajanjeDataModel
            { ID = 1, Trajanje = "10 minuta", BrojZauzetihTermina = 2 },
            new Models.DataModel.TrajanjeDataModel
            { ID = 2, Trajanje = "15 minuta", BrojZauzetihTermina = 3 },
            new Models.DataModel.TrajanjeDataModel
            { ID = 3, Trajanje = "30 minuta", BrojZauzetihTermina = 6 },
            new Models.DataModel.TrajanjeDataModel
            { ID = 4, Trajanje = "45 minuta", BrojZauzetihTermina = 9 },
            new Models.DataModel.TrajanjeDataModel
            { ID = 5, Trajanje = "60 minuta", BrojZauzetihTermina = 12 },
             new Models.DataModel.TrajanjeDataModel
            { ID = 6, Trajanje = "120 minuta", BrojZauzetihTermina = 24 }
        };

        public static Models.ViewModel.ProstorijaViewModel pvm = new Models.ViewModel.ProstorijaViewModel();
        public ActionResult ProstorijaView()
        {
            pvm.ProstorijaList.Clear();

            foreach (Prostorija prostorija in db.Prostorijas)
            {
                if (prostorija.Dostupnost == true)
                {
                    pvm.ProstorijaList.Add(prostorija);
                }
            }
            return View(pvm);
        }

        public ActionResult ProstorijaStoloviView()
        {
            pvm.ProstorijaList.Clear();

            foreach (Prostorija prostorija in db.Prostorijas)
            {
                if (prostorija.Dostupnost == true && PravaProstorija(prostorija, 2) == true)
                {
                    pvm.ProstorijaList.Add(prostorija);
                }
            }
            return View(pvm);
        }

        bool PravaProstorija(Prostorija prostorija, int KategorijaOpreme)
        {
            bool value = false;
            foreach (Oprema oprema in db.Opremas)
            {
                if (oprema.ProstorijaID.Value == prostorija.ID && oprema.KategorijaOpremeID == KategorijaOpreme)
                {
                    value = true;
                }
            }
            return value;
        }

        public ActionResult ProstorijaRacunalaView()
        {
            pvm.ProstorijaList.Clear();

            foreach (Prostorija prostorija in db.Prostorijas)
            {
                if (prostorija.Dostupnost == true && PravaProstorija(prostorija, 1) == true)
                {
                    pvm.ProstorijaList.Add(prostorija);
                }
            }
            return View(pvm);
        }

        public ActionResult ProstorijaPrinteriView()
        {
            pvm.ProstorijaList.Clear();

            foreach (Prostorija prostorija in db.Prostorijas)
            {
                if (prostorija.Dostupnost == true && PravaProstorija(prostorija, 5) == true)
                {
                    pvm.ProstorijaList.Add(prostorija);
                }
            }
            return View(pvm);
        }

        public Models.ViewModel.OpremaViewModel ovm = new Models.ViewModel.OpremaViewModel();
        public ActionResult OpremaView(int? ProstorijaID)
        {
            ovm.OpremaList.Clear();
            if (ProstorijaID != null)
            {
                Prostorija mp = db.Prostorijas.FirstOrDefault(pr => pr.ID == ProstorijaID);
                foreach (Oprema oprema in mp.Opremas)
                {
                    ovm.OpremaList.Add(oprema);
                }
            }
            return View(ovm);
        }

        public static Models.ViewModel.DatumiViewModel dvm = new Models.ViewModel.DatumiViewModel();
        public ActionResult DatumiView()
        {
            dvm.DatumiList.Clear();
            foreach (Models.DataModel.DatumiDataModel datum in Datumi)
            {
                dvm.DatumiList.Add(datum);
            }
            return View(dvm);
        }


        public static Models.ViewModel.DanTerminViewModel dtvm = new Models.ViewModel.DanTerminViewModel();
        public ActionResult DanTerminView(int? DatumRezervacijeID, int? OpremaID)
        {
            dtvm.DanTerminiList.Clear();

            if (DatumRezervacijeID != null && OpremaID != null)
            {
                int datumDropdownID = DatumRezervacijeID.Value;
                DateTime datum = Datumi[datumDropdownID - 1].DatumiRezervacije;

                foreach (DanTermini termin in db.DanTerminis)
                {
                    dtvm.DanTerminiList.Add(termin);
                }

                foreach (Rezervacija rezervacija in db.Rezervacijas)
                {
                    if (rezervacija.DatumRezervacije == datum && rezervacija.OpremaID == OpremaID && rezervacija.RezervacijaAktivna == true)
                    {
                        dtvm.DanTerminiList.Remove(rezervacija.DanTermini);
                    }
                }
            }
            return View(dtvm);
        }

        public static Models.ViewModel.TrajanjeViewModel tvm = new Models.ViewModel.TrajanjeViewModel();
        public ActionResult TrajanjeView(int? DatumRezervacijeID, int? OpremaID, int? DanTerminiID)
        {
            tvm.TrajanjeList.Clear();

            if (DatumRezervacijeID != null && OpremaID != null && DanTerminiID != null)
            {
                int DatumRezervacije = DatumRezervacijeID.Value;
                int Oprema = OpremaID.Value;
                int DanTermini = DanTerminiID.Value;

                foreach (Models.DataModel.TrajanjeDataModel tr in TrajanjeList)
                {
                    tvm.TrajanjeList.Add(tr);
                }

                // Brojac zauzetih dana nakon termina
                int razlikaTermina = 0;
                int brojacZauzetiTerminV = 24;
                int brojacZauzetiTermin = 24;
                int MaxTermina = 145;
                int razlikaMaxTerminTemp = 144;
                int razlikaMaxTermin = 144;

                foreach (Rezervacija rezervacija in db.Rezervacijas)
                {
                    if (rezervacija.DatumRezervacije == Datumi[DatumRezervacijeID.Value - 1].DatumiRezervacije
                        && rezervacija.OpremaID == OpremaID)
                    {
                        // Trazi dan termine (23 - 120 minuta je maksimalni broj)
                        if (rezervacija.DanTerminiID >= DanTerminiID && rezervacija.DanTerminiID <= DanTerminiID + 23 && rezervacija.RezervacijaAktivna == true)
                        {
                            // Trazi slobodne termine do slijedeceg zauzetog
                            razlikaTermina = rezervacija.DanTerminiID.Value - DanTerminiID.Value;
                            if (razlikaTermina < brojacZauzetiTerminV)
                            {
                                brojacZauzetiTerminV = razlikaTermina;
                                if (brojacZauzetiTermin > brojacZauzetiTerminV)
                                {
                                    brojacZauzetiTermin = brojacZauzetiTerminV;
                                }
                            }
                        }
                    }
                    if (DanTerminiID >= (MaxTermina - DanTerminiID))
                    {
                        // Trazi slobodne termine do kraja terminListe
                        razlikaMaxTerminTemp = MaxTermina - DanTerminiID.Value;
                        if (razlikaMaxTerminTemp < razlikaMaxTermin)
                        {
                            razlikaMaxTermin = razlikaMaxTerminTemp;
                        }
                    }

                    // Stvarni broj slobodnih termina do gornje granice
                    if (razlikaMaxTermin < brojacZauzetiTermin)
                    {
                        brojacZauzetiTermin = razlikaMaxTermin;
                    }
                }

                int KategorijaOpreme = db.Opremas.Find(OpremaID).KategorijaOpremeID.Value;

                if (KategorijaOpreme != 1)
                {
                    brojacZauzetiTermin = 1;
                }

                // Trajanje lista
                foreach (Models.DataModel.TrajanjeDataModel tr2 in TrajanjeList)
                {
                    if (tr2.BrojZauzetihTermina > brojacZauzetiTermin)
                    {
                        tvm.TrajanjeList.Remove(tr2);
                    }
                }
            }
            return View(tvm);
        }
    }
}
