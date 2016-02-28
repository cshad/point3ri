using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace point3ri_Alpha_0._51.Models.DataModel
{
    public class DatumiDataModel
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DatumiRezervacije { get; set; }
        public string DatumiRezervacijeString { get; set; }
    }
}
