namespace point3ri.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MVC_Pringup : DbContext
    {
        public MVC_Pringup()
            : base("name=MVC_Pringup")
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<KategorijaOpreme> KategorijaOpremes { get; set; }
        public virtual DbSet<Oprema> Opremas { get; set; }
        public virtual DbSet<PrijavaLosegStanjaOpreme> PrijavaLosegStanjaOpremes { get; set; }
        public virtual DbSet<Prostorija> Prostorijas { get; set; }
        public virtual DbSet<Rezervacija> Rezervacijas { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<VrijemeTermina> VrijemeTerminas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("UserId").MapRightKey("RoleId"));

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
        }
    }
}
