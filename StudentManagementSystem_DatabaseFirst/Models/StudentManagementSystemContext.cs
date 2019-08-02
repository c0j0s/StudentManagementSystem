using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudentManagementSystem_DatabaseFirst.Models
{
    public partial class StudentManagementSystemContext : DbContext
    {
        public StudentManagementSystemContext()
        {
        }

        public StudentManagementSystemContext(DbContextOptions<StudentManagementSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<Diploma> Diploma { get; set; }
        public virtual DbSet<Modules> Modules { get; set; }
        public virtual DbSet<StudentModules> StudentModules { get; set; }
        public virtual DbSet<Students> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\Lab;Database=StudentManagementSystem;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.HasKey(e => e.AddressId);

                entity.HasIndex(e => e.AdminNo)
                    .IsUnique()
                    .HasFilter("([AdminNo] IS NOT NULL)");

                entity.Property(e => e.AdminNo).HasMaxLength(7);

                entity.Property(e => e.StreetName).IsRequired();

                entity.HasOne(d => d.AdminNoNavigation)
                    .WithOne(p => p.Addresses)
                    .HasForeignKey<Addresses>(d => d.AdminNo);
            });

            modelBuilder.Entity<Diploma>(entity =>
            {
                entity.Property(e => e.DiplomaId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Modules>(entity =>
            {
                entity.HasKey(e => e.ModuleId);

                entity.Property(e => e.ModuleId).ValueGeneratedNever();
            });

            modelBuilder.Entity<StudentModules>(entity =>
            {
                entity.HasKey(e => new { e.AdminNo, e.ModuleId });

                entity.HasIndex(e => e.ModuleId);

                entity.Property(e => e.AdminNo).HasMaxLength(7);

                entity.HasOne(d => d.AdminNoNavigation)
                    .WithMany(p => p.StudentModules)
                    .HasForeignKey(d => d.AdminNo);

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.StudentModules)
                    .HasForeignKey(d => d.ModuleId);
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.AdminNo);

                entity.HasIndex(e => e.DiplomaId);

                entity.Property(e => e.AdminNo)
                    .HasMaxLength(7)
                    .ValueGeneratedNever();

                entity.Property(e => e.ContactNumber).IsRequired();

                entity.Property(e => e.Gender).HasMaxLength(1);

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Diploma)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.DiplomaId);
            });
        }
    }
}
