namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_HospitalDatabase.Data.Models;
    using P01_HospitalDatabase.Config;

    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }

        public HospitalContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Medicament> Medicaments { get; set; }
        public virtual DbSet<Visitation> Visitations { get; set; }
        public virtual DbSet<Diagnose> Diagnoses { get; set; }
        public virtual DbSet<PatientMedicament> Prescriptions { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }

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
            builder.Entity<Patient>().HasKey(id => id.PatientId);
            builder.Entity<Patient>().Property(id => id.PatientId);
            builder.Entity<Patient>().Property(n => n.FirstName).HasMaxLength(50).IsUnicode(true);
            builder.Entity<Patient>().Property(n => n.LastName).HasMaxLength(50).IsUnicode(true);
            builder.Entity<Patient>().Property(a => a.Address).HasMaxLength(250).IsUnicode(true);
            builder.Entity<Patient>().Property(e => e.Email).HasMaxLength(80).IsUnicode(false);

            builder.Entity<Patient>()
                .HasMany(v => v.Visitations)
                .WithOne(p => p.Patient)
                .HasForeignKey(p => p.PatientId);

            builder.Entity<Patient>()
                .HasMany(d => d.Diagnoses)
                .WithOne(p => p.Patient)
                .HasForeignKey(p => p.PatientId);

            builder.Entity<Patient>()
                .HasMany(pm => pm.Prescriptions)
                .WithOne(p => p.Patient)
                .HasForeignKey(p => p.PatientId);

            builder.Entity<Visitation>().HasKey(id => id.VisitationId);
            builder.Entity<Visitation>().Property(c => c.Comments).HasMaxLength(250).IsUnicode(true);
            builder.Entity<Visitation>().Property(d => d.Date).HasDefaultValueSql("GetDate()");

            builder.Entity<Medicament>().HasKey(id => id.MedicamentId);
            builder.Entity<Medicament>().Property(id => id.Name).HasMaxLength(50).IsUnicode(true);

            builder.Entity<Medicament>()
               .HasMany(pm => pm.Prescriptions)
               .WithOne(p => p.Medicament)
               .HasForeignKey(p => p.MedicamentId);

            builder.Entity<Diagnose>().HasKey(id => id.DiagnoseId);
            builder.Entity<Diagnose>().Property(n => n.Name).HasMaxLength(50).IsUnicode(true);
            builder.Entity<Diagnose>().Property(c => c.Name).HasMaxLength(250).IsUnicode(true);

            builder.Entity<PatientMedicament>()
                .ToTable("PatientsMedicaments");

            builder.Entity<PatientMedicament>()
                .HasKey(pm => new
                {
                    pm.PatientId,
                    pm.MedicamentId,
                });

            builder.Entity<Doctor>().HasKey(id => id.DoctorId);
            builder.Entity<Doctor>().Property(n => n.Name).HasMaxLength(100).IsUnicode(true);
            builder.Entity<Doctor>().Property(s => s.Specialty).HasMaxLength(100).IsUnicode(true);


            builder.Entity<Doctor>()
                .HasMany(v => v.Visitations)
                .WithOne(c => c.Doctor)
                .HasForeignKey(c => c.DoctorId);
        }
    }
}
