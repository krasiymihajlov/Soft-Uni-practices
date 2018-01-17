namespace P01_1BillsPaymentSystem.Data.Configurations
{
    using P01_1BillsPaymentSystem.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasKey(pk => pk.Id);
            builder.Property(t => t.Type).IsRequired();
            builder.HasIndex(k => new { k.UserId, k.BankAccountId, k.CreditCardId }).IsUnique();
                

            builder.HasOne(u => u.User)
                .WithMany(pm => pm.PaymentMethods)
                .HasForeignKey(fk => fk.UserId);

            builder.HasOne(pm => pm.CreditCard)
                .WithOne(c => c.PaymentMethod)
                .HasForeignKey<PaymentMethod>(pm => pm.CreditCardId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pm => pm.BankAccount)
                .WithOne(c => c.PaymentMethod)
                .HasForeignKey<PaymentMethod>(pm => pm.BankAccountId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
