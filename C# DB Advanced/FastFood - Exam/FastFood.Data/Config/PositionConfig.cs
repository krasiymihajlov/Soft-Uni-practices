namespace FastFood.Data.Config
{
    using FastFood.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PositionConfig : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => x.Name);
        }
    }
}
