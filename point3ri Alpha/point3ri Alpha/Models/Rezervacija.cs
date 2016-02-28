namespace point3ri_Alpha_0._51.Models
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
            OdjavljeneRezervacijes = new HashSet<OdjavljeneRezervacije>();
            PrijavaLosegStanjaOpremes = new HashSet<PrijavaLosegStanjaOpreme>();
        }

        public int ID { get; set; }

        [StringLength(128)]
        public string KorisnikID { get; set; }

        [Display(Name = "Datum rezervacije")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DatumRezervacije { get; set; }

        [Required]
        public int? DanTerminiID { get; set; }

        [Required]
        public int? OpremaID { get; set; }

        [Required]
        public int? ProstorijaID { get; set; }

        [Display(Name = "Vrijeme rezerviranja")]
        public DateTime? VrijemeRezerviranja { get; set; }

        public bool? RezervacijaAktivna { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual DanTermini DanTermini { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OdjavljeneRezervacije> OdjavljeneRezervacijes { get; set; }

        public virtual Oprema Oprema { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrijavaLosegStanjaOpreme> PrijavaLosegStanjaOpremes { get; set; }

        public virtual Prostorija Prostorija { get; set; }
    }
}
