namespace point3ri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KategorijaOpreme_Prostorije
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? OpremaID { get; set; }

        public int? ProstorijaID { get; set; }

        public int? KoličinaOpreme { get; set; }

        public virtual Oprema Oprema { get; set; }

        public virtual Prostorije Prostorije { get; set; }
    }
}
