﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementSystem_CodeFirst.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diploma",
                columns: table => new
                {
                    DiplomaId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diploma", x => x.DiplomaId);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    ModuleId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.ModuleId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    AdminNo = table.Column<string>(maxLength: 7, nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Dob = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(maxLength: 1, nullable: true),
                    ContactNumber = table.Column<string>(nullable: false),
                    DiplomaId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.AdminNo);
                    table.ForeignKey(
                        name: "FK_Students_Diploma_DiplomaId",
                        column: x => x.DiplomaId,
                        principalTable: "Diploma",
                        principalColumn: "DiplomaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StreetName = table.Column<string>(nullable: false),
                    Details = table.Column<string>(nullable: true),
                    PostalCode = table.Column<int>(nullable: false),
                    AdminNo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_Students_AdminNo",
                        column: x => x.AdminNo,
                        principalTable: "Students",
                        principalColumn: "AdminNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentModules",
                columns: table => new
                {
                    AdminNo = table.Column<string>(nullable: false),
                    ModuleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentModules", x => new { x.AdminNo, x.ModuleId });
                    table.ForeignKey(
                        name: "FK_StudentModules_Students_AdminNo",
                        column: x => x.AdminNo,
                        principalTable: "Students",
                        principalColumn: "AdminNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentModules_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Diploma",
                columns: new[] { "DiplomaId", "Name" },
                values: new object[,]
                {
                    { "C36", "Common ICT Programme" },
                    { "C35", "Business & Financial Technology" },
                    { "C43", "Business & Financial Technology" },
                    { "C54", "Cybersecurity & Digital Forensics " },
                    { "C80", "Infocomm & Security " },
                    { "C85", "Information Technology  " }
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "ModuleId", "Name" },
                values: new object[,]
                {
                    { "IT1010", "Data Analysis & Visualisation" },
                    { "IT1020", "Fundamentals of Innovation & Enterprise" },
                    { "IT1030", "Infocomm Security" },
                    { "IT1040", "Network Technology" },
                    { "IT1050", "Web Development" },
                    { "IT1060", "Programming Essentials" },
                    { "ITX150", "App Development Project" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AdminNo",
                table: "Addresses",
                column: "AdminNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentModules_ModuleId",
                table: "StudentModules",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DiplomaId",
                table: "Students",
                column: "DiplomaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "StudentModules");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Diploma");
        }
    }
}
