using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAO.Context
{
    public class RMDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Table> Tables { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<TableOrderDetails> TableOrderDetails { get; set; }

        public DbSet<ProductOrderDetails> ProductOrderDetails { get; set; }

        public DbSet<Bill> Bills { get; set; }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connStr = @"Data Source = LAPTOP - BV87SDMM\HAU; Initial Catalog = RestaurantManagement; Integrated Security = true; ;TrustServerCertificate=true ";
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithOne(e => e.Category)
                .HasForeignKey(e => e.CategoryID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Region>()
                .HasMany(e => e.Tables)
                .WithOne(e => e.Region)
                .HasForeignKey(e => e.RegionID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Orders)
                .WithOne(e => e.Employee)
                .HasForeignKey(e => e.EmployeeID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Orders)
                .WithOne(e => e.Customer)
                .HasForeignKey(e => e.CustomerID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.TableOrderDetails)
                .WithOne(e => e.Order)
                .HasForeignKey(e => e.OrderID);

            modelBuilder.Entity<Table>()
                .HasMany(e => e.TableOrderDetails)
                .WithOne(e => e.Table)
                .HasForeignKey(e => e.TableID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductOrderDetails)
                .WithOne(e => e.Product)
                .HasForeignKey(e => e.ProductID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<TableOrderDetails>()
                .HasMany(e => e.ProductOrderDetails)
                .WithOne(e => e.TableOrderDetails)
                .HasForeignKey(e => e.TableOrDtID);

            modelBuilder.Entity<Bill>()
                .HasOne(e => e.Order)
                .WithOne(e => e.Bill)
                .HasForeignKey<Bill>(e => e.OrderID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Account)
                .WithOne(e => e.Employee)
                .HasForeignKey<Employee>(e => e.Username);

        }

    }
}

