namespace P01_StudentSystem.Data.Configuration
{
    using P01_StudentSystem.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            builder.HasKey(k => k.HomeworkId);
            builder.Property(c => c.Content).IsUnicode(false).IsRequired(true); 
            builder.Property(ct => ct.ContentType).IsRequired(true).IsUnicode();
            builder.Property(d => d.SubmissionTime).HasDefaultValueSql("GETDATE()");

            builder.HasOne(c => c.Course)
                .WithMany(h => h.HomeworkSubmissions)
                .HasForeignKey(c => c.CourseId);

            builder.HasOne(s => s.Student)
               .WithMany(h => h.HomeworkSubmissions)
               .HasForeignKey(s => s.StudentId);
        }
    }
}
