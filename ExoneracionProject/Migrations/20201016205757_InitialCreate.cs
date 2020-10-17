using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExoneracionProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nationalidentifier = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Department = table.Column<string>(nullable: true),
                    JobTittle = table.Column<string>(nullable: true),
                    Salary = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    JobName = table.Column<string>(nullable: true),
                    MinSalary = table.Column<string>(nullable: true),
                    MaxSalary = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Candidatos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NationalIdentifier = table.Column<string>(nullable: true),
                    Cellphone = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Salary = table.Column<string>(nullable: true),
                    Languages = table.Column<int>(nullable: false),
                    Grades = table.Column<int>(nullable: false),
                    CompetencesId = table.Column<Guid>(nullable: false),
                    JobId = table.Column<Guid>(nullable: true),
                    PreviousJob = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidatos_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Competences",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    CandidatoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competences_Candidatos_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Candidatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobExperiences",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    JobTittle = table.Column<string>(nullable: true),
                    From = table.Column<DateTime>(nullable: false),
                    To = table.Column<DateTime>(nullable: false),
                    Salary = table.Column<int>(nullable: false),
                    CandidatoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobExperiences_Candidatos_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Candidatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidatos_JobId",
                table: "Candidatos",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Competences_CandidatoId",
                table: "Competences",
                column: "CandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_JobExperiences_CandidatoId",
                table: "JobExperiences",
                column: "CandidatoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "Competences");

            migrationBuilder.DropTable(
                name: "JobExperiences");

            migrationBuilder.DropTable(
                name: "Candidatos");

            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
