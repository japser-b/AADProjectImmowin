using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace AAD.ImmoWin.Business.Classes
{
    public class EFContect : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data source=(localdb)\MSSQLLocalDB;initial catalog=ImmoWinProject");
        }

        public DbSet<Klant> Klanten { get; set; }

        public DbSet<Woning> Woningen { get; set; }

        public DbSet<Adres> Adressen { get; set; }

        public DbSet<Huis> Huizen { get; set; }

        public DbSet<Appartement> Appartementen { get; set; }
        public DbSet<Bod> Boden { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Woning>()
                .HasOne(woning => woning.Adres)
                .WithOne()
                .HasForeignKey<Woning>(woning => woning.AdresId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Klant>()
                .HasOne(klant => klant.Adres)
                .WithOne()
                .HasForeignKey<Klant>(klant => klant.AdresId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Huis>()
                .ToTable("tblHuizen")
                .HasBaseType<Woning>(); // `Huis` erft van `Woning`

            // Configuratie voor Huis
            modelBuilder.Entity<Appartement>()
                .ToTable("tblAppartementen")
                .HasBaseType<Woning>(); // `Huis` erft van `Woning`

            modelBuilder.Entity<Bod>()
                .HasOne(bod => bod.Woning)
                .WithMany(woning => woning.Biedingen)  // Zorg ervoor dat de 'Woning' een 'Biedingen' navigatieeigenschap heeft
                .HasForeignKey(bod => bod.WoningId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
