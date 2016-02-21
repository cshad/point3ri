using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace point3ri_Alpha_0._51.Models.DataModel
{
    public class TrajanjeDataModel
    {
        [Required]
        public int ID { get; set; }
        public string Trajanje { get; set; }
        public int BrojZauzetihTermina { get; set; }        
    }
}
