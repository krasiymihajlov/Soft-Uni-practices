namespace Stations.Data.Config
{
    using Microsoft.EntityFrameworkCore;
    using Stations.Models;
    using System;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CustomerCardConfig : IEntityTypeConfiguration<CustomerCard>
    {
        public void Configure(EntityTypeBuilder<CustomerCard> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Age);
        }
    }
}
