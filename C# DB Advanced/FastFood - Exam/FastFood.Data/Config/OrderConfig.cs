namespace FastFood.Data.Config
{
    using FastFood.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Ignore(x => x.TotalPrice);

            builder.HasOne(x => x.Employee)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.EmployeeId);
        }
    }
}
