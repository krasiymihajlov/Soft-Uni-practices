namespace P03_SalesDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data.Models;

    public class SalesContext : DbContext
    {
        public SalesContext()
        {
        }

        public SalesContext(DbContextOptions options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);

            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Config.FullDataBasePath);
            }
        }
    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Product Fluent Api
            builder.Entity<Product>().HasKey(id => id.ProductId);
            builder.Entity<Product>().Property(n => n.Name).HasMaxLength(50).IsUnicode(true);
            builder.Entity<Product>().Property(d => d.Description).HasMaxLength(250).HasDefaultValueSql("No description");


            builder.Entity<Product>()
                .HasMany(s => s.Sales)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId);
            

            //Customer Fluent Api
            builder.Entity<Customer>().HasKey(id => id.CustomerId);
            builder.Entity<Customer>().Property(n => n.Name).HasMaxLength(100).IsUnicode(true);
            builder.Entity<Customer>().Property(e => e.Email).HasMaxLength(80).IsUnicode(false);

            builder.Entity<Customer>()
                .HasMany(s => s.Sales)
                .WithOne(c => c.Customer)
                .HasForeignKey(c => c.CustomerId);

            //Store Fluent Api
            builder.Entity<Store>().HasKey(id => id.StoreId);
            builder.Entity<Store>().Property(n => n.Name).HasMaxLength(80).IsUnicode(true);

            builder.Entity<Store>()
                .HasMany(s => s.Sales)
                .WithOne(st => st.Store)
                .HasForeignKey(st => st.StoreId);

            //Sales Fluent Api
            builder.Entity<Sale>().HasKey(id => id.SaleId);
            builder.Entity<Sale>().Property(d => d.Date).HasDefaultValueSql("GETDATE()");
        }
    }
}
