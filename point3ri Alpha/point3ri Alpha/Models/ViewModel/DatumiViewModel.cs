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
        public List<DataModel.DatumiDataModel> DatumiList = new List<DataModel.DatumiDataModel>();
        public int SelectedDatumRezervacijeID { get; set; }
        public IEnumerable<SelectListItem> DatumiRezervacijeIEnum
        {
            get
            {
                return new SelectList(DatumiList, "ID", "DatumiRezervacije");
            }
        }

    }
}
