namespace point3ri_Alpha_0._51.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Oprema")]
    public partial class Oprema
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Oprema()
        {
            Rezervacijas = new HashSet<Rezervacija>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(255)]
        public string Naziv { get; set; }

        public int? KategorijaOpremeID { get; set; }

        [StringLength(255)]
        public string InventarskiBroj { get; set; }

        public int? ProstorijaID { get; set; }

        public virtual KategorijaOpreme KategorijaOpreme { get; set; }

        public virtual Prostorija Prostorija { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rezervacija> Rezervacijas { get; set; }
    }
}
