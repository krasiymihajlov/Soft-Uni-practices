namespace P01_StudentSystem.Data.Configuration
{
    using P01_StudentSystem.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ResourceCofiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasKey(k => k.ResourceId);
            builder.Property(n => n.Name).HasMaxLength(50).IsUnicode(true).IsRequired(true);
            builder.Property(u => u.Url).IsUnicode(false).IsRequired(true);
            builder.Property(u => u.ResourceType).IsUnicode(true).IsRequired(true);

            builder.HasOne(c => c.Course)
                .WithMany(r => r.Resources)
                .HasForeignKey(c => c.CourseId);
        }
    }
}
