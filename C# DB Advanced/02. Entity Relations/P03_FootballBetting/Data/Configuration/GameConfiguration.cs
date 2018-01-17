namespace P03_FootballBetting.Data.Configuration
{
    using P03_FootballBetting.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(pk => pk.GameId);

            builder.HasOne(t => t.AwayTeam)
                .WithMany(c => c.AwayGames)
                .HasForeignKey(fk => fk.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.HomeTeam)
                .WithMany(c => c.HomeGames)
                .HasForeignKey(fk => fk.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }   
    }
}
