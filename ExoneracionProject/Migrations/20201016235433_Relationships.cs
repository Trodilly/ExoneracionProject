using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExoneracionProject.Migrations
{
    public partial class Relationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competences_Candidatos_CandidatoId",
                table: "Competences");

            migrationBuilder.DropForeignKey(
                name: "FK_JobExperiences_Candidatos_CandidatoId",
                table: "JobExperiences");

            migrationBuilder.DropColumn(
                name: "CompetencesId",
                table: "Candidatos");

            migrationBuilder.DropColumn(
                name: "PreviousJob",
                table: "Candidatos");

            migrationBuilder.AlterColumn<Guid>(
                name: "CandidatoId",
                table: "JobExperiences",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CandidatoId",
                table: "Competences",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Competences_Candidatos_CandidatoId",
                table: "Competences",
                column: "CandidatoId",
                principalTable: "Candidatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobExperiences_Candidatos_CandidatoId",
                table: "JobExperiences",
                column: "CandidatoId",
                principalTable: "Candidatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competences_Candidatos_CandidatoId",
                table: "Competences");

            migrationBuilder.DropForeignKey(
                name: "FK_JobExperiences_Candidatos_CandidatoId",
                table: "JobExperiences");

            migrationBuilder.AlterColumn<Guid>(
                name: "CandidatoId",
                table: "JobExperiences",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CandidatoId",
                table: "Competences",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "CompetencesId",
                table: "Candidatos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PreviousJob",
                table: "Candidatos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Competences_Candidatos_CandidatoId",
                table: "Competences",
                column: "CandidatoId",
                principalTable: "Candidatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobExperiences_Candidatos_CandidatoId",
                table: "JobExperiences",
                column: "CandidatoId",
                principalTable: "Candidatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
