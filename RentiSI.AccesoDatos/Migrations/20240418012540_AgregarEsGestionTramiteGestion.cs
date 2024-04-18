using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentiSI.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarEsGestionTramiteGestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gestion_TipoDetalleEstado_IdTipoRechazo",
                table: "Gestion");

            migrationBuilder.RenameColumn(
                name: "IdTipoRechazo",
                table: "Gestion",
                newName: "IdDetalleEstado");

            migrationBuilder.RenameIndex(
                name: "IX_Gestion_IdTipoRechazo",
                table: "Gestion",
                newName: "IX_Gestion_IdDetalleEstado");

            migrationBuilder.AddColumn<bool>(
                name: "EsGestionTramite",
                table: "Gestion",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Gestion_TipoDetalleEstado_IdDetalleEstado",
                table: "Gestion",
                column: "IdDetalleEstado",
                principalTable: "TipoDetalleEstado",
                principalColumn: "IdTipoDetalleEstado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gestion_TipoDetalleEstado_IdDetalleEstado",
                table: "Gestion");

            migrationBuilder.DropColumn(
                name: "EsGestionTramite",
                table: "Gestion");

            migrationBuilder.RenameColumn(
                name: "IdDetalleEstado",
                table: "Gestion",
                newName: "IdTipoRechazo");

            migrationBuilder.RenameIndex(
                name: "IX_Gestion_IdDetalleEstado",
                table: "Gestion",
                newName: "IX_Gestion_IdTipoRechazo");

            migrationBuilder.AddForeignKey(
                name: "FK_Gestion_TipoDetalleEstado_IdTipoRechazo",
                table: "Gestion",
                column: "IdTipoRechazo",
                principalTable: "TipoDetalleEstado",
                principalColumn: "IdTipoDetalleEstado");
        }
    }
}
