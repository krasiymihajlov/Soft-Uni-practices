namespace P03_FootballBetting.Data.Configuration
{
    using P03_FootballBetting.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PlayerStatisticConfiguration : IEntityTypeConfiguration<PlayerStatistic>
    {
        public void Configure(EntityTypeBuilder<PlayerStatistic> builder)
        {
            builder.HasKey(pk => new { pk.GameId, pk.PlayerId });

            builder.HasOne(g => g.Game)
                .WithMany(ps => ps.PlayerStatistics)
                .HasForeignKey(fk => fk.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Player)
                .WithMany(ps => ps.PlayerStatistics)
                .HasForeignKey(fk => fk.PlayerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
