namespace point3ri_Alpha_0._51.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OdjavljeneRezervacije")]
    public partial class OdjavljeneRezervacije
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public DateTime? VrijemeOdjave { get; set; }

        public int? IDRezervacija { get; set; }

        public virtual Rezervacija Rezervacija { get; set; }
    }
}
