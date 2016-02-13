using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace point3ri_Alpha_0._51.Models.ViewModel
{
    class ProstorijaViewModel
    {
        public List<Models.Prostorija> ProstorijaList = new List<Models.Prostorija>();
        public int SelectedProstorijaID { get; set; }
        public IEnumerable<SelectListItem> ProstorijaIEnum
        {
            get
            {
                return new SelectList(ProstorijaList, "ID", "Naziv");
            }
        }
    }
}
