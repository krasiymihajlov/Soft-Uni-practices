namespace P01_1BillsPaymentSystem.Data.Configurations
{
    using P01_1BillsPaymentSystem.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(pk => pk.UserId);
            builder.Property(n => n.FirstName).IsRequired().IsUnicode().HasMaxLength(50);
            builder.Property(n => n.LastName).IsRequired().IsUnicode().HasMaxLength(50);
            builder.Property(e => e.Email).IsRequired().IsUnicode(false).HasMaxLength(80);
            builder.Property(p => p.Password).IsRequired().IsUnicode(false).HasMaxLength(25);
        }
    }
}
