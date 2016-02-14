using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace point3ri_Alpha_0._51.Models.ViewModel
{
    public class OpremaViewModel
    {
        public List<Models.Oprema> OpremaList = new List<Models.Oprema>();
        public int SelectedOpremaID { get; set; }
        public IEnumerable<SelectListItem> OpremaIEnum
        {
            get
            {
                return new SelectList(OpremaList, "ID", "Naziv");
            }
        }
    }
}
