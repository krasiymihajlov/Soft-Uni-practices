namespace P03_FootballBetting.Data.Configuration
{
    using P03_FootballBetting.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(pk => pk.TeamId);
            builder.Property(n => n.Name).IsRequired().IsUnicode().HasMaxLength(80);
            builder.Property(i => i.Initials).IsRequired().IsUnicode().HasMaxLength(3);
            builder.Property(l => l.LogoUrl).IsRequired();

            builder.HasOne(ptc => ptc.PrimaryKitColor)
                .WithMany(t => t.PrimaryKitTeams)
                .HasForeignKey(fk => fk.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(stc => stc.SecondaryKitColor)
                .WithMany(t => t.SecondaryKitTeams)
                .HasForeignKey(fk => fk.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);            

            builder.HasOne(t => t.Town)
                .WithMany(c => c.Teams)
                .HasForeignKey(fk => fk.TownId)
                .OnDelete(DeleteBehavior.Restrict);            
        }
    }
}
