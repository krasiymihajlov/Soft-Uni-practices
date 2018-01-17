namespace Stations.Data.Config
{
    using Microsoft.EntityFrameworkCore;
    using Stations.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TrainConfig : IEntityTypeConfiguration<Train>
    {
        public void Configure(EntityTypeBuilder<Train> builder)
        {
            builder.HasKey(pk => pk.Id);
            builder.HasAlternateKey(a => a.TrainNumber);
            builder.Property(x => x.TrainNumber).HasMaxLength(10);
        }
    }
}
