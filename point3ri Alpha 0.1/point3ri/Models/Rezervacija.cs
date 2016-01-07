namespace point3ri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rezervacija")]
    public partial class Rezervacija
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rezervacija()
        {
            PrijavaLosegStanjaOpremes = new HashSet<PrijavaLosegStanjaOpreme>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(128)]
        public string KorisnikID { get; set; }

        public int? OpremaID { get; set; }

        public DateTime? Termin { get; set; }

        public int? Prostorija { get; set; }

        public int? RedniBrojOpreme { get; set; }

        public DateTime? VrijemeRezervacija { get; set; }

        public DateTime? VrijemeOdjaveRezervacije { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Oprema Oprema { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrijavaLosegStanjaOpreme> PrijavaLosegStanjaOpremes { get; set; }
    }
}
