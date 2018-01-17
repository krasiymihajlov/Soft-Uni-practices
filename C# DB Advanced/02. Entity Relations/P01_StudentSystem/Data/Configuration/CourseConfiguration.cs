namespace P01_StudentSystem.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_StudentSystem.Data.Models;

    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
        }
        
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.CourseId);
            builder.Property(n => n.Name).HasMaxLength(80).IsUnicode(true).IsRequired();
            builder.Property(d => d.Description).IsUnicode(true).IsRequired(false);
            builder.Property(dt => dt.StartDate).HasDefaultValueSql("GETDATE()");
            builder.Property(dt => dt.EndDate).IsRequired(true);
        }
    }
}
