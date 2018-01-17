namespace Stations.Data.Config
{
    using Microsoft.EntityFrameworkCore;
    using Stations.Models;
    using System;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TicketConfig : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Trip)
                .WithMany(x => x.Tickets)
                .HasForeignKey(x => x.TripId);

            builder.HasOne(x => x.CustomerCard)
                .WithMany(x => x.BoughtTickets)
                .HasForeignKey(x => x.CustomerCardId);
        }
    }
}
