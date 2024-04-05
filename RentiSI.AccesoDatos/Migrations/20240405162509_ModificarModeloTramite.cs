using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentiSI.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class ModificarModeloTramite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tramite_AspNetUsers_IdUsuarioGestion",
                table: "Tramite");

            migrationBuilder.DropForeignKey(
                name: "FK_Tramite_AspNetUsers_IdUsuarioReasignacion",
                table: "Tramite");

            migrationBuilder.DropForeignKey(
                name: "FK_Tramite_AspNetUsers_IdUsuarioRecibe",
                table: "Tramite");

            migrationBuilder.DropForeignKey(
                name: "FK_Tramite_AspNetUsers_IdUsuarioResuelve",
                table: "Tramite");

            migrationBuilder.DropForeignKey(
                name: "FK_Tramite_AspNetUsers_IdUsuarioRevision",
                table: "Tramite");

            migrationBuilder.DropIndex(
                name: "IX_Tramite_IdUsuarioGestion",
                table: "Tramite");

            migrationBuilder.DropIndex(
                name: "IX_Tramite_IdUsuarioReasignacion",
                table: "Tramite");

            migrationBuilder.DropIndex(
                name: "IX_Tramite_IdUsuarioRecibe",
                table: "Tramite");

            migrationBuilder.DropIndex(
                name: "IX_Tramite_IdUsuarioResuelve",
                table: "Tramite");

            migrationBuilder.DropIndex(
                name: "IX_Tramite_IdUsuarioRevision",
                table: "Tramite");

            migrationBuilder.DropColumn(
                name: "EstadoGestion",
                table: "Tramite");

            migrationBuilder.DropColumn(
                name: "EstadoRevision",
                table: "Tramite");

            migrationBuilder.DropColumn(
                name: "FechaGestion",
                table: "Tramite");

            migrationBuilder.DropColumn(
                name: "FechaReasignacion",
                table: "Tramite");

            migrationBuilder.DropColumn(
                name: "FechaRecepcion",
                table: "Tramite");

            migrationBuilder.DropColumn(
                name: "FechaResultado",
                table: "Tramite");

            migrationBuilder.DropColumn(
                name: "FechaRevision",
                table: "Tramite");

            migrationBuilder.DropColumn(
                name: "IdUsuarioGestion",
                table: "Tramite");

            migrationBuilder.DropColumn(
                name: "IdUsuarioReasignacion",
                table: "Tramite");

            migrationBuilder.DropColumn(
                name: "IdUsuarioRecibe",
                table: "Tramite");

            migrationBuilder.DropColumn(
                name: "IdUsuarioResuelve",
                table: "Tramite");

            migrationBuilder.DropColumn(
                name: "IdUsuarioRevision",
                table: "Tramite");

            migrationBuilder.DropColumn(
                name: "NumeroGuia",
                table: "Tramite");

            migrationBuilder.DropColumn(
                name: "OrganismoTransito",
                table: "Tramite");

            migrationBuilder.DropColumn(
                name: "TipificacionCasuisticaImpronta",
                table: "Tramite");

            migrationBuilder.DropColumn(
                name: "TipificacionCasuisticaRevision",
                table: "Tramite");

            migrationBuilder.DropColumn(
                name: "TipificacionImpronta",
                table: "Tramite");

            migrationBuilder.DropColumn(
                name: "TipificacionTramiteRevision",
                table: "Tramite");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EstadoGestion",
                table: "Tramite",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstadoRevision",
                table: "Tramite",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FechaGestion",
                table: "Tramite",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FechaReasignacion",
                table: "Tramite",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FechaRecepcion",
                table: "Tramite",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FechaResultado",
                table: "Tramite",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FechaRevision",
                table: "Tramite",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdUsuarioGestion",
                table: "Tramite",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdUsuarioReasignacion",
                table: "Tramite",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdUsuarioRecibe",
                table: "Tramite",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdUsuarioResuelve",
                table: "Tramite",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdUsuarioRevision",
                table: "Tramite",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroGuia",
                table: "Tramite",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrganismoTransito",
                table: "Tramite",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipificacionCasuisticaImpronta",
                table: "Tramite",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipificacionCasuisticaRevision",
                table: "Tramite",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipificacionImpronta",
                table: "Tramite",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipificacionTramiteRevision",
                table: "Tramite",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tramite_IdUsuarioGestion",
                table: "Tramite",
                column: "IdUsuarioGestion");

            migrationBuilder.CreateIndex(
                name: "IX_Tramite_IdUsuarioReasignacion",
                table: "Tramite",
                column: "IdUsuarioReasignacion");

            migrationBuilder.CreateIndex(
                name: "IX_Tramite_IdUsuarioRecibe",
                table: "Tramite",
                column: "IdUsuarioRecibe");

            migrationBuilder.CreateIndex(
                name: "IX_Tramite_IdUsuarioResuelve",
                table: "Tramite",
                column: "IdUsuarioResuelve");

            migrationBuilder.CreateIndex(
                name: "IX_Tramite_IdUsuarioRevision",
                table: "Tramite",
                column: "IdUsuarioRevision");

            migrationBuilder.AddForeignKey(
                name: "FK_Tramite_AspNetUsers_IdUsuarioGestion",
                table: "Tramite",
                column: "IdUsuarioGestion",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tramite_AspNetUsers_IdUsuarioReasignacion",
                table: "Tramite",
                column: "IdUsuarioReasignacion",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tramite_AspNetUsers_IdUsuarioRecibe",
                table: "Tramite",
                column: "IdUsuarioRecibe",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tramite_AspNetUsers_IdUsuarioResuelve",
                table: "Tramite",
                column: "IdUsuarioResuelve",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tramite_AspNetUsers_IdUsuarioRevision",
                table: "Tramite",
                column: "IdUsuarioRevision",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
