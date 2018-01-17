namespace Stations.Data.Config
{
    using Microsoft.EntityFrameworkCore;
    using Stations.Models;
    using System;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TrainSeatConfig : IEntityTypeConfiguration<TrainSeat>
    {
        public void Configure(EntityTypeBuilder<TrainSeat> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(s => s.Train)
                .WithMany(x => x.TrainSeats)
                .HasForeignKey(x => x.TrainId);

            builder.HasOne(x => x.SeatingClass)
                .WithMany(x => x.TrainSeats)
                .HasForeignKey(x => x.SeatingClassId);
        }
    }
}
