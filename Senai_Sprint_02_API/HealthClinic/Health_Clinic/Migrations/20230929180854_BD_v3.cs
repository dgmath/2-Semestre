using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Health_Clinic.Migrations
{
    /// <inheritdoc />
    public partial class BD_v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HorarioFuncionamento",
                table: "Clinica",
                newName: "HorarioFechamento");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HorarioAbertura",
                table: "Clinica",
                type: "TIME",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorarioAbertura",
                table: "Clinica");

            migrationBuilder.RenameColumn(
                name: "HorarioFechamento",
                table: "Clinica",
                newName: "HorarioFuncionamento");
        }
    }
}
