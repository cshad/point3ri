using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace point3ri_Alpha_0._51.Models.ViewModel
{
    class DanTerminViewModel
    {
        public List<DanTermini> DanTerminiList = new List<DanTermini>();
        public int SelectedDanTerminiID { get; set; }
        public IEnumerable<SelectListItem> DanTerminiIEnum
        {
            get
            {
                return new SelectList(DanTerminiList, "ID", "Termin");
            }
        }


    }
}
