namespace Stations.Data.Config
{
    using Microsoft.EntityFrameworkCore;
    using Stations.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class StationConfig : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            builder.HasKey(pk => pk.Id);
            builder.HasAlternateKey(ak => ak.Name);
            builder.Property(x => x.Name).HasMaxLength(50);

            builder.Property(t => t.Town).IsRequired().HasMaxLength(50);
        }
    }
}
