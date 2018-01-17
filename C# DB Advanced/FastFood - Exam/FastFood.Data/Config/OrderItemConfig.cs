namespace FastFood.Data.Config
{
    using FastFood.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(x => new { x.ItemId, x.OrderId });

            builder.HasOne(x => x.Item)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.ItemId);

            builder.HasOne(x => x.Order)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.OrderId);
        }
    }
}
