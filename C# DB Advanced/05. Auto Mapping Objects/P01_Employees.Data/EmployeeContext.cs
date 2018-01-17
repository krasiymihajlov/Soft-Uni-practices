namespace P01_Employees.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_Employees.Data.Configurations;
    using P01_Employees.Models;
    using System;

    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
        {
        }

        public EmployeeContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);

            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Config.FullDataBasePath);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new EmployeeConfiguration());
        }
    }
}
