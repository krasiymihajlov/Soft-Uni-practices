namespace ProductShop.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ProductShop.Models;

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(pk => pk.Id);
            builder.Property(n => n.Name).IsRequired();
            builder.Property(p => p.Price).IsRequired();

            builder.HasOne(bi => bi.Buyer)
                .WithMany(u => u.ProductsBought)
                .HasForeignKey(fk => fk.BuyerId);

            builder.HasOne(si => si.Seller)
                .WithMany(u => u.ProductsSold)
                .HasForeignKey(fk => fk.SellerId);
        }
    }
}
