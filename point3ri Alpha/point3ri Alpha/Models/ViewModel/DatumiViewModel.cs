using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace point3ri_Alpha_0._51.Models.ViewModel
{
    public class DatumiViewModel
    {
        public List<DateTime> DatumiList = new List<DateTime>();
        public int SelectedDatumRezervacije { get; set; }
        public IEnumerable<SelectListItem> DatumiIEnum
        {
            get
            {
                return new SelectList(DatumiList);
            }
        }

    }
}
