using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace point3ri_Alpha_0._51.Models.ViewModel
{
    class KategorijaOpremeViewModel
    {
        public List<Models.KategorijaOpreme> KategorijaOpremeList = new List<Models.KategorijaOpreme>();
        public int SelectedKategorijaOpremeID { get; set; }
        public IEnumerable<SelectListItem> KategorijaOpremeIEnum
        {
            get
            {
                return new SelectList(KategorijaOpremeList, "ID", "NazivKategorije");
            }
        }
    }
}
