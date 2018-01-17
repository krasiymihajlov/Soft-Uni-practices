namespace P01_StudentSystem.Data.Configuration
{
    using P01_StudentSystem.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(id => id.StudentId);
            builder.Property(n => n.Name).HasMaxLength(100).IsUnicode(true).IsRequired(true);
            builder.Property(pn => pn.PhoneNumber).HasColumnType("CHAR(10)").IsRequired(true); 
            builder.Property(d => d.RegisteredOn).HasDefaultValueSql("GETDATE()");
            builder.Property(d => d.Birthday).IsRequired(false);
        }
    }
}
