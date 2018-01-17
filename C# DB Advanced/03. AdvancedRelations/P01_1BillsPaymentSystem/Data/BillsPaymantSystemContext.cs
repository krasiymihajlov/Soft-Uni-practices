namespace P01_1BillsPaymentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_1BillsPaymentSystem.Data.Configurations;
    using P01_1BillsPaymentSystem.Data.Models;

    public class BillsPaymantSystemContext : DbContext
    {
        public BillsPaymantSystemContext()
        {
        }

        public BillsPaymantSystemContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }

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
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new CreditCardConfiguration());
            builder.ApplyConfiguration(new BankAccountConfiguration());
            builder.ApplyConfiguration(new PaymentMethodConfiguration());
        }
    }
}
