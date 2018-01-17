namespace P03_FootballBetting.Data.Configuration
{
    using P03_FootballBetting.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TownConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder.HasKey(pk => pk.TownId);
            builder.Property(n => n.Name).IsRequired().IsUnicode().HasMaxLength(100);

            builder.HasOne(c => c.Country)
                .WithMany(t => t.Towns)
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.Restrict)  ;
        }
    }
}
