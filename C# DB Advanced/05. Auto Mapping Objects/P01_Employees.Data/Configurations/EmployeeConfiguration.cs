namespace P01_Employees.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_Employees.Models;

    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(pk => pk.EmployeeId);
            builder.Property(fn => fn.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(ln => ln.LastName).IsRequired().HasMaxLength(50);
            builder.Property(s => s.Salary).IsRequired();
            builder.Property(d => d.BirthDay).IsRequired(false);
            builder.Property(a => a.Address).IsRequired(false).HasMaxLength(20);
            builder.Property(m => m.ManagerId).IsRequired(false);

            builder.HasOne(m => m.Manager)
                .WithMany(e => e.Employees)
                .HasForeignKey(m => m.ManagerId);
        }
    }
}
