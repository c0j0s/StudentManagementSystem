using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem_CodeFirst.Models
{
    public class StudentManagementSystemContext : DbContext
    {
        public StudentManagementSystemContext(DbContextOptions<StudentManagementSystemContext> options): base(options)
        { }

        public DbSet<Diploma> Diploma { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<StudentModules> StudentModules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasOne(i => i.Student)
                .WithOne(c => c.Address)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentModules>()
            .HasKey(sm => new { sm.AdminNo, sm.ModuleId });

            modelBuilder.Entity<StudentModules>()
                .HasOne(s => s.Student)
                .WithMany(sm => sm.StudentModules)
                .HasForeignKey(s => s.AdminNo);

            modelBuilder.Entity<StudentModules>()
                .HasOne(m => m.Module)
                .WithMany(sm => sm.StudentModules)
                .HasForeignKey(m => m.ModuleId);

        }

    }

}
