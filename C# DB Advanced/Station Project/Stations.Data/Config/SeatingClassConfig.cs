namespace Stations.Data.Config
{
    using Microsoft.EntityFrameworkCore;
    using Stations.Models;
    using System;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SeatingClassConfig : IEntityTypeConfiguration<SeatingClass>
    {
        public void Configure(EntityTypeBuilder<SeatingClass> builder)
        {
            builder.HasKey(pk => pk.Id);
            builder.HasAlternateKey(x => new
            {
                x.Name,
                x.Abbreviation,
            });

            builder.Property(x => x.Name).HasMaxLength(30);

            builder.Property(x => x.Abbreviation).IsRequired();
        }
    }
}
