using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace point3ri_Alpha_0._51.Models.ViewModel
{
    public class TrajanjeViewModel
    {
        public List<DataModel.TrajanjeDataModel> TrajanjeList = new List<DataModel.TrajanjeDataModel>();
        public int SelectedTrajanjeID { get; set; }
        public IEnumerable<SelectListItem> TrajanjeIEnum
        {
            get
            {
                return new SelectList(TrajanjeList, "ID", "Trajanje", "BrojZauzetihTermina");
            }
        } 
    }
}
