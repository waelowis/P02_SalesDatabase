using Microsoft.EntityFrameworkCore;
using P02_SalesDatabase.Models;

namespace P02_SalesDatabase.Data
{
    internal class SalesContext : DbContext
    {

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Store> Stores { get; set; } = null!;
        public DbSet<Sale> Sales { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=WAEL;Initial Catalog=P02_SalesDatabase; User ID=sa;Password=1562014;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Entity-Product 
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode(true);

            modelBuilder.Entity<Product>()
                  .Property(p => p.Quantity)
                  .HasColumnType("real");

            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .HasMaxLength(250)
                .HasDefaultValue("No description");




            //Entity-Customer  
            modelBuilder.Entity<Customer>()
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsUnicode(true);

            modelBuilder.Entity<Customer>()
                .Property(p => p.Email)
                .HasMaxLength(80)
                .IsUnicode(false);

            //Entity - sales
            modelBuilder.Entity<Sale>()
                .Property(e => e.Date)
                .HasDefaultValueSql("GETDATE()");

            // Entity - Store
            modelBuilder.Entity<Store>()
                .Property(e => e.Name)
                .HasMaxLength(80)
                .IsUnicode(true);

            // realtion ship

            modelBuilder.Entity<Product>()
                .HasMany(p => p.sales)
                .WithOne(s => s.product)
                .HasForeignKey(s => s.ProductId);



            modelBuilder.Entity<Customer>()
                .HasMany(c => c.sales)
                .WithOne(s => s.Customer)
                .HasForeignKey(s => s.CustomerId);



            modelBuilder.Entity<Store>()
                .HasMany(s => s.sales)
                .WithOne(s => s.Store)
                .HasForeignKey(s => s.StoreId);


            //seedData
            SeedInitialData(modelBuilder);

        }

        private static void SeedInitialData(ModelBuilder modelBuilder)
        {

            List<Product> products = new List<Product>
            {
                new Product { ProductId = 1, Name = "Laptop Pro", Quantity = 100, Price = 1200.00m },
                new Product { ProductId = 2, Name = "Mechanical Keyboard", Quantity = 250, Price = 80.50m },
                new Product { ProductId = 3, Name = "Gaming Mouse", Quantity = 300, Price = 45.00m },
                new Product { ProductId = 4, Name = "USB-C Hub", Quantity = 150, Price = 30.00m }
            };
            modelBuilder.Entity<Product>().HasData(products);


            List<Customer> customers = new List<Customer>
            {
                new Customer { CustomerId = 1, Name = "Ali Abdullah", Email = "wael.mohamed@example.com", CreaditCardNumber = "1111222233334444" },
                new Customer { CustomerId = 2, Name = "Fatima Saeed", Email = "mohamed.wael@example.com", CreaditCardNumber = "5555666677778888" },
                new Customer { CustomerId = 3, Name = "Omar Khaled", Email = "wael_mohamed@example.com", CreaditCardNumber = "9999000011112222" }
            };
            modelBuilder.Entity<Customer>().HasData(customers);


            List<Store> stores = new List<Store>
            {
                new Store { StoreId = 1, Name = "Cairo" },
                new Store { StoreId = 2, Name = "Giza" }
            };
            modelBuilder.Entity<Store>().HasData(stores);



            List<Sale> sales = new List<Sale>
            {
                new Sale { SaleId = 1, Date = new DateTime(2025, 5, 20, 10, 30, 0), ProductId = 1, CustomerId = 1, StoreId = 1 },
                new Sale { SaleId = 2, Date = new DateTime(2025, 5, 21, 14, 0, 0), ProductId = 2, CustomerId = 2, StoreId = 2 },
                new Sale { SaleId = 3, Date = new DateTime(2025, 5, 21, 15, 15, 0), ProductId = 3, CustomerId = 1, StoreId = 1 },
                new Sale { SaleId = 4, Date = new DateTime(2025, 5, 22, 11, 0, 0), ProductId = 1, CustomerId = 3, StoreId = 2 }
            };
            modelBuilder.Entity<Sale>().HasData(sales);
        }

    }
}
