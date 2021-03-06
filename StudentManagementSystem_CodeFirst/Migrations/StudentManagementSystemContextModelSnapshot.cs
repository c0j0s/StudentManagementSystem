﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentManagementSystem_CodeFirst.Models;

namespace StudentManagementSystem_CodeFirst.Migrations
{
    [DbContext(typeof(StudentManagementSystemContext))]
    partial class StudentManagementSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudentManagementSystem_CodeFirst.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdminNo")
                        .IsRequired();

                    b.Property<string>("Details");

                    b.Property<int>("PostalCode");

                    b.Property<string>("StreetName")
                        .IsRequired();

                    b.HasKey("AddressId");

                    b.HasIndex("AdminNo")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("StudentManagementSystem_CodeFirst.Models.Diploma", b =>
                {
                    b.Property<string>("DiplomaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("DiplomaId");

                    b.ToTable("Diploma");

                    b.HasData(
                        new
                        {
                            DiplomaId = "C36",
                            Name = "Common ICT Programme"
                        },
                        new
                        {
                            DiplomaId = "C35",
                            Name = "Business & Financial Technology"
                        },
                        new
                        {
                            DiplomaId = "C43",
                            Name = "Business & Financial Technology"
                        },
                        new
                        {
                            DiplomaId = "C54",
                            Name = "Cybersecurity & Digital Forensics "
                        },
                        new
                        {
                            DiplomaId = "C80",
                            Name = "Infocomm & Security "
                        },
                        new
                        {
                            DiplomaId = "C85",
                            Name = "Information Technology  "
                        });
                });

            modelBuilder.Entity("StudentManagementSystem_CodeFirst.Models.Module", b =>
                {
                    b.Property<string>("ModuleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ModuleId");

                    b.ToTable("Modules");

                    b.HasData(
                        new
                        {
                            ModuleId = "IT1010",
                            Name = "Data Analysis & Visualisation"
                        },
                        new
                        {
                            ModuleId = "IT1020",
                            Name = "Fundamentals of Innovation & Enterprise"
                        },
                        new
                        {
                            ModuleId = "IT1030",
                            Name = "Infocomm Security"
                        },
                        new
                        {
                            ModuleId = "IT1040",
                            Name = "Network Technology"
                        },
                        new
                        {
                            ModuleId = "IT1050",
                            Name = "Web Development"
                        },
                        new
                        {
                            ModuleId = "IT1060",
                            Name = "Programming Essentials"
                        },
                        new
                        {
                            ModuleId = "ITX150",
                            Name = "App Development Project"
                        });
                });

            modelBuilder.Entity("StudentManagementSystem_CodeFirst.Models.Student", b =>
                {
                    b.Property<string>("AdminNo")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(7);

                    b.Property<string>("ContactNumber")
                        .IsRequired();

                    b.Property<string>("DiplomaId")
                        .IsRequired();

                    b.Property<DateTime>("Dob");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(1);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("AdminNo");

                    b.HasIndex("DiplomaId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentManagementSystem_CodeFirst.Models.StudentModules", b =>
                {
                    b.Property<string>("AdminNo");

                    b.Property<string>("ModuleId");

                    b.HasKey("AdminNo", "ModuleId");

                    b.HasIndex("ModuleId");

                    b.ToTable("StudentModules");
                });

            modelBuilder.Entity("StudentManagementSystem_CodeFirst.Models.Address", b =>
                {
                    b.HasOne("StudentManagementSystem_CodeFirst.Models.Student", "Student")
                        .WithOne("Address")
                        .HasForeignKey("StudentManagementSystem_CodeFirst.Models.Address", "AdminNo")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentManagementSystem_CodeFirst.Models.Student", b =>
                {
                    b.HasOne("StudentManagementSystem_CodeFirst.Models.Diploma", "Diploma")
                        .WithMany("Students")
                        .HasForeignKey("DiplomaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentManagementSystem_CodeFirst.Models.StudentModules", b =>
                {
                    b.HasOne("StudentManagementSystem_CodeFirst.Models.Student", "Student")
                        .WithMany("StudentModules")
                        .HasForeignKey("AdminNo")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StudentManagementSystem_CodeFirst.Models.Module", "Module")
                        .WithMany("StudentModules")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
