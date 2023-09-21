using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.@event.tarde.Migrations
{
    /// <inheritdoc />
    public partial class BD_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Idusuario",
                table: "Usuario",
                newName: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "Usuario",
                newName: "Idusuario");
        }
    }
}
