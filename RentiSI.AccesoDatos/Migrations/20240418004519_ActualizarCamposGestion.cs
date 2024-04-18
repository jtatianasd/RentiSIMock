using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentiSI.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarCamposGestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdTipoRechazo",
                table: "Gestion",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gestion_IdTipoRechazo",
                table: "Gestion",
                column: "IdTipoRechazo");

            migrationBuilder.AddForeignKey(
                name: "FK_Gestion_TipoDetalleEstado_IdTipoRechazo",
                table: "Gestion",
                column: "IdTipoRechazo",
                principalTable: "TipoDetalleEstado",
                principalColumn: "IdTipoDetalleEstado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gestion_TipoDetalleEstado_IdTipoRechazo",
                table: "Gestion");

            migrationBuilder.DropIndex(
                name: "IX_Gestion_IdTipoRechazo",
                table: "Gestion");

            migrationBuilder.DropColumn(
                name: "IdTipoRechazo",
                table: "Gestion");
        }
    }
}
