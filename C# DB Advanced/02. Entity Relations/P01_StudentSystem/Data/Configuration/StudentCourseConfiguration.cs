namespace P01_StudentSystem.Data.Configuration
{
    using P01_StudentSystem.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.HasKey(pk => new { pk.CourseId, pk.StudentId });

            builder.HasOne(c => c.Course)
                .WithMany(c => c.StudentsEnrolled)
                .HasForeignKey(fk => fk.CourseId);

            builder.HasOne(s => s.Student)
                .WithMany(c => c.CourseEnrollments)
                .HasForeignKey(fk => fk.StudentId);
        }
    }
}
