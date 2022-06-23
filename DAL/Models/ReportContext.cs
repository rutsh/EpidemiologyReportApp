using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Models
{
    public partial class ReportContext : DbContext
    {
        public ReportContext()
        {
        }

        public ReportContext(DbContextOptions<ReportContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Report;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.City).HasMaxLength(1);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ExactLocation).HasMaxLength(1);

                entity.Property(e => e.PatientId).HasMaxLength(9);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Patient)
                    .WithMany()
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Locations__Patie__4BAC3F29");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.Property(e => e.PatientId).HasMaxLength(9);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
