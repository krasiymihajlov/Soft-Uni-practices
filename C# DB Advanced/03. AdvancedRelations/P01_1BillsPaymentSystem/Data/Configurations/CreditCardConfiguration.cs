namespace P01_1BillsPaymentSystem.Data.Configurations
{
    using P01_1BillsPaymentSystem.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.HasKey(pk => pk.CreditCardId);
            builder.Ignore(l => l.LimitLeft);
            builder.Property(l => l.Limit).IsRequired();
            builder.Property(m => m.MoneyOwed).IsRequired();
            builder.Property(d => d.ExpirationDate).IsRequired();
        }
    }
}
