namespace P03_FootballBetting.Data.Configuration
{
    using P03_FootballBetting.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(pk => pk.UserId);
            builder.Property(p => p.Name).IsRequired().IsUnicode().HasMaxLength(50);
            builder.Property(p => p.Username).IsRequired().IsUnicode().HasMaxLength(100);
            builder.Property(p => p.Password).IsRequired().IsUnicode();
            builder.Property(p => p.Email).IsRequired().IsUnicode();
        }
    }
}
