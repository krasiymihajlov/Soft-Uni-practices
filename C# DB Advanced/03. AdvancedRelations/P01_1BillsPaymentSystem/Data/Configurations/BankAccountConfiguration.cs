namespace P01_1BillsPaymentSystem.Data.Configurations
{
    using P01_1BillsPaymentSystem.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasKey(pk => pk.BankAccountId);
            builder.Property(bn => bn.BankName).IsRequired().IsUnicode().HasMaxLength(50);
            builder.Property(bn => bn.SWIFTCode).IsRequired().IsUnicode(false).HasMaxLength(20);
            builder.Property(bn => bn.Balance).IsRequired();
        }
    }
}
