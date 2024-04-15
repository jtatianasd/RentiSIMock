using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentiSI.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarUsuarioATablaTramite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdUsuarioAsignacion",
                table: "Tramite",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tramite_IdUsuarioAsignacion",
                table: "Tramite",
                column: "IdUsuarioAsignacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Tramite_AspNetUsers_IdUsuarioAsignacion",
                table: "Tramite",
                column: "IdUsuarioAsignacion",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tramite_AspNetUsers_IdUsuarioAsignacion",
                table: "Tramite");

            migrationBuilder.DropIndex(
                name: "IX_Tramite_IdUsuarioAsignacion",
                table: "Tramite");

            migrationBuilder.DropColumn(
                name: "IdUsuarioAsignacion",
                table: "Tramite");
        }
    }
}
