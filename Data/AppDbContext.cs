using Microsoft.EntityFrameworkCore;
using wmsmagazyn.Models;

namespace wmsmagazyn.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Access> Accesses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<StockMovement> StockMovements { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Lokalizacje
            modelBuilder.Entity<Location>().HasData(
                new Location { Id = 1, Name = "Lodówka" },
                new Location { Id = 2, Name = "Szafka" },
                new Location { Id = 3, Name = "Blat" }
            );

            // Seed Użytkownicy
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Mateusz", Surname = "Walter", Role = "Kierownik" },
                new User { Id = 2, Name = "Adam", Surname = "Kowalski", Role = "Magazynier" },
                new User { Id = 3, Name = "Jarek", Surname = "Wiśniewski", Role = "Magazynier" }
            );

            // Seed Produkty
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Mleko", Barcode = "111111", Unit = "l", Price = 3.50m, DefaultLocationId = 1 },
                new Product { Id = 2, Name = "Szynka", Barcode = "222222", Unit = "kg", Price = 25.00m, DefaultLocationId = 1 },
                new Product { Id = 3, Name = "Jabłka", Barcode = "333333", Unit = "kg", Price = 4.00m, DefaultLocationId = 3 },
                new Product { Id = 4, Name = "Chleb", Barcode = "444444", Unit = "szt", Price = 5.00m, DefaultLocationId = 2 },
                new Product { Id = 5, Name = "Płatki", Barcode = "555555", Unit = "paczka", Price = 8.00m, DefaultLocationId = 2 }
            );
        }
    }
}
