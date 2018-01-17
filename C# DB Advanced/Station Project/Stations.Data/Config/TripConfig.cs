namespace Stations.Data.Config
{
    using Microsoft.EntityFrameworkCore;
    using Stations.Models;
    using System;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TripConfig : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasKey(pk => pk.Id);

            builder.HasOne(x => x.OriginStation)
                .WithMany(x => x.TripsFrom)
                .HasForeignKey(x => x.OriginStationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.DestinationStation)
                .WithMany(x => x.TripsTo)
                .HasForeignKey(x => x.DestinationStationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Train)
                .WithMany(x => x.Trips)
                .HasForeignKey(x => x.TrainId);
        }
    }
}
