using point3ri_Alpha_0._51.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace point3ri_Alpha_0._51.Controllers
{
    public class HomeController : Controller
    {
        private point3ri db = new point3ri();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Obavijesti()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        // funkcija za trazenje slobodnih termina
        public int BrojSlobodnihRezervacija(int KategorijaOpreme)
        {
            int brojSlobodnih = 0;
            int trenutnoZauzeti = 0;
            int brojOpreme = db.Opremas.Count(o => o.KategorijaOpremeID == KategorijaOpreme);

            foreach (Rezervacija rezervacija in db.Rezervacijas)
            {
                if (rezervacija.Oprema.KategorijaOpremeID == KategorijaOpreme &&
                    rezervacija.RezervacijaAktivna == true &&
                    rezervacija.DatumRezervacije == DateTime.Today &&
                    rezervacija.DanTermini.Termin >= DateTime.Now.TimeOfDay)
                {
                    trenutnoZauzeti += 1;
                }

            }
            brojSlobodnih = brojOpreme - trenutnoZauzeti;
            return brojSlobodnih;
        }
    }
}