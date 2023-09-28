using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Health_Clinic.Migrations
{
    /// <inheritdoc />
    public partial class BD_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "HorarioFuncionamento",
                table: "Clinica",
                type: "TIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "HorarioFuncionamento",
                table: "Clinica",
                type: "DATETIME",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "TIME");
        }
    }
}
