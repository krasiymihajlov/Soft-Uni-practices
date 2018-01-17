namespace P03_FootballBetting.Data.Configuration
{
    using P03_FootballBetting.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BetConfiguration : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            builder.HasKey(fk => fk.BetId);
            builder.Property(p => p.Prediction).IsRequired().IsUnicode();

            builder.HasOne(u => u.User)
                .WithMany(b => b.Bets)
                .HasForeignKey(fk => fk.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(g => g.Game)
               .WithMany(b => b.Bets)
               .HasForeignKey(fk => fk.GameId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
