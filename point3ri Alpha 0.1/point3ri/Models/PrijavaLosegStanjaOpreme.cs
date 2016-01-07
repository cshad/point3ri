namespace point3ri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PrijavaLosegStanjaOpreme")]
    public partial class PrijavaLosegStanjaOpreme
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? RezervacijaID { get; set; }

        public bool PronadenoStanje { get; set; }

        public virtual Rezervacija Rezervacija { get; set; }
    }
}
