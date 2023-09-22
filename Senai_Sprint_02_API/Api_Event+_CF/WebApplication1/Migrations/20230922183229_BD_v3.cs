using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.@event.tarde.Migrations
{
    /// <inheritdoc />
    public partial class BD_v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComentarioEvento",
                columns: table => new
                {
                    IdComentarioEveto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    Exibe = table.Column<bool>(type: "BIT", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentarioEvento", x => x.IdComentarioEveto);
                    table.ForeignKey(
                        name: "FK_ComentarioEvento_Evento_IdEvento",
                        column: x => x.IdEvento,
                        principalTable: "Evento",
                        principalColumn: "IdEvento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComentarioEvento_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioEvento_IdEvento",
                table: "ComentarioEvento",
                column: "IdEvento");

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioEvento_IdUsuario",
                table: "ComentarioEvento",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComentarioEvento");
        }
    }
}
