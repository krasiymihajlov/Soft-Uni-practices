namespace P03_FootballBetting.Data.Configuration
{
    using P03_FootballBetting.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(pk => pk.PlayerId);
            builder.Property(n => n.Name).IsRequired().IsUnicode().HasMaxLength(100);
            builder.HasIndex(sn => sn.SquadNumber).IsUnique();

            builder.HasOne(p => p.Position)
                .WithMany(p => p.Players)
                .HasForeignKey(fk => fk.PositionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Team)
                .WithMany(p => p.Players)
                .HasForeignKey(fk => fk.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
