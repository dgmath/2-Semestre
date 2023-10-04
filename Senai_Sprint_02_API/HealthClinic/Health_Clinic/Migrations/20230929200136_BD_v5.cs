using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Health_Clinic.Migrations
{
    /// <inheritdoc />
    public partial class BD_v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Consulta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Consulta",
                type: "VARCHAR(100)",
                nullable: false,
                defaultValue: "");
        }
    }
}
