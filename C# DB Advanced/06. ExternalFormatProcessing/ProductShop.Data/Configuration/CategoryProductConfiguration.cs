namespace ProductShop.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ProductShop.Models;

    public class CategoryProductConfiguration : IEntityTypeConfiguration<CategoryProduct>
    {
        public void Configure(EntityTypeBuilder<CategoryProduct> builder)
        {
            builder.HasKey(pk => new { pk.CategoryId, pk.ProductId });

            builder.HasOne(p => p.Product)
                .WithMany(c => c.Categories)
                .HasForeignKey(fk => fk.ProductId);

            builder.HasOne(c => c.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(fk => fk.CategoryId);
        }
    }
}
