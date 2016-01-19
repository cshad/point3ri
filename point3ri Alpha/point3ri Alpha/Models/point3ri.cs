namespace point3ri_Alpha_0._51.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class point3ri : DbContext
    {
        public point3ri()
            : base("name=point3ri")
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<DanTermini> DanTerminis { get; set; }
        public virtual DbSet<KategorijaOpreme> KategorijaOpremes { get; set; }
        public virtual DbSet<OdjavljeneRezervacije> OdjavljeneRezervacijes { get; set; }
        public virtual DbSet<Oprema> Opremas { get; set; }
        public virtual DbSet<PrijavaLosegStanjaOpreme> PrijavaLosegStanjaOpremes { get; set; }
        public virtual DbSet<Prostorija> Prostorijas { get; set; }
        public virtual DbSet<Rezervacija> Rezervacijas { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Rezervacijas)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.KorisnikID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KategorijaOpreme>()
                .Property(e => e.NazivKategorije)
                .IsUnicode(false);

            modelBuilder.Entity<Rezervacija>()
                .HasMany(e => e.OdjavljeneRezervacijes)
                .WithOptional(e => e.Rezervacija)
                .HasForeignKey(e => e.IDRezervacija);
        }
    }
}
