using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia13.Models
{
    public class CukierniaDbContext : DbContext
    {
        public DbSet<Klient>Clients { get; set; }
        public DbSet<Zamowienie> Orders { get; set; }
        public DbSet<WyrobCukierniczy> Products { get; set; }
        public DbSet<Zamowienie_WyrobCukierniczy> OrdersProducts { get; set; }
        public CukierniaDbContext()
        {
                
        }
        public CukierniaDbContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Klient>((builder) =>
            {
                builder.HasKey(a => a.IdKlient);
                builder.Property(a => a.IdKlient).ValueGeneratedOnAdd();
                builder.Property(a => a.Imie).IsRequired();
                builder.Property(a => a.Nazwisko).IsRequired();

                builder.HasMany(a => a.Orders).WithOne(a => a.Klient).HasForeignKey(a => a.IdKlient).IsRequired();

                var dictStudies = new List<Klient>();
                dictStudies.Add(new Klient { IdKlient = 1, Imie = "Norbert", Nazwisko = "Gierczak" });
                dictStudies.Add(new Klient { IdKlient = 2, Imie = "Łukasz", Nazwisko = "Zygmunciak" });

                modelBuilder.Entity<Klient>()
                            .HasData(dictStudies);
            });
            modelBuilder.Entity<Pracownik>((builder) =>
            {
                builder.HasKey(a => a.IdPracownik);
                builder.Property(a => a.IdPracownik).ValueGeneratedOnAdd();
                builder.Property(a => a.Imie).IsRequired();
                builder.Property(a => a.Nazwisko).IsRequired();

                builder.HasMany(a => a.Orders).WithOne(a => a.Pracownik).HasForeignKey(a => a.IdPracownik).IsRequired();
               
                var dictStudies = new List<Pracownik>();
                dictStudies.Add(new Pracownik { IdPracownik = 1, Imie = "Paweł", Nazwisko = "Szabla" });
                dictStudies.Add(new Pracownik { IdPracownik = 2, Imie = "Łukasz", Nazwisko = "Tak" });

                modelBuilder.Entity<Pracownik>()
                            .HasData(dictStudies);
            });
            modelBuilder.Entity<Zamowienie>((builder) =>
            {
                builder.HasKey(a => a.IdZamowienia);
                builder.Property(a => a.IdZamowienia).ValueGeneratedOnAdd();
               

                builder.HasMany(a => a.OrdersProducts).WithOne(a => a.Zamowienie).HasForeignKey(a => a.IdZamowienia).IsRequired();
                
                var dictStudies = new List<Zamowienie>();
                dictStudies.Add(new Zamowienie { IdZamowienia = 1,DataPrzyjecia = DateTime.Now,DataRealizacji = new DateTime(2020,6,5),IdKlient=1,IdPracownik=2 });
                dictStudies.Add(new Zamowienie { IdZamowienia = 2, DataPrzyjecia = DateTime.Now, DataRealizacji = new DateTime(2020,8, 5), IdKlient = 1, IdPracownik = 2 });
                dictStudies.Add(new Zamowienie { IdZamowienia = 3, DataPrzyjecia = DateTime.Now, DataRealizacji = new DateTime(2020, 6, 4), IdKlient = 2, IdPracownik = 1 });

                modelBuilder.Entity<Zamowienie>()
                            .HasData(dictStudies);
            });
            modelBuilder.Entity<WyrobCukierniczy>((builder) =>
            {
                builder.HasKey(a => a.IdWyrobuCukierniczego);
                builder.Property(a => a.IdWyrobuCukierniczego).ValueGeneratedOnAdd();


                builder.HasMany(a => a.OrdersProducts).WithOne(a => a.WyrobCukierniczy).HasForeignKey(a => a.IdWyrobuCukierniczego).IsRequired();
                
                var dictStudies = new List<WyrobCukierniczy>();
                dictStudies.Add(new WyrobCukierniczy { IdWyrobuCukierniczego = 1, Nazwa = "sernik", CenaZaSzt = 5f, Typ = "ciasto" });
                dictStudies.Add(new WyrobCukierniczy { IdWyrobuCukierniczego = 2, Nazwa = "szarlotka", CenaZaSzt = 8f, Typ = "ciasto" });
               
                modelBuilder.Entity<WyrobCukierniczy>()
                            .HasData(dictStudies);
            });
            modelBuilder.Entity<Zamowienie_WyrobCukierniczy>((builder) =>
            {
                builder.HasKey(a => new { a.IdWyrobuCukierniczego , a.IdZamowienia });
               // builder.HasKey(a => a.IdZamowienia);

                var dictStudies = new List<Zamowienie_WyrobCukierniczy>();
                dictStudies.Add(new Zamowienie_WyrobCukierniczy { IdZamowienia = 1,IdWyrobuCukierniczego = 1, Ilosc = 1 });
                dictStudies.Add(new Zamowienie_WyrobCukierniczy { IdZamowienia = 2,IdWyrobuCukierniczego = 2, Ilosc = 3});
                dictStudies.Add(new Zamowienie_WyrobCukierniczy { IdZamowienia = 3, IdWyrobuCukierniczego = 2, Ilosc = 7});

                modelBuilder.Entity<Zamowienie_WyrobCukierniczy>()
                            .HasData(dictStudies);

            });
        }
    }
}
