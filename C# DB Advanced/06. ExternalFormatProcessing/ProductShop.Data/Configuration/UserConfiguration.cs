namespace ProductShop.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ProductShop.Models;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(pk => pk.Id);
            builder.Property(fn => fn.FirstName).IsRequired(false);
            builder.Property(ln => ln.LastName).IsRequired();
            builder.Property(a => a.Age).IsRequired(false);
        }
    }
}
