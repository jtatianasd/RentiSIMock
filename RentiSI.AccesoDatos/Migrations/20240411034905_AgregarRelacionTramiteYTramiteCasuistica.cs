using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentiSI.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRelacionTramiteYTramiteCasuistica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TramiteCasuistica_Id_Casuistica",
                table: "TramiteCasuistica",
                column: "Id_Casuistica");

            migrationBuilder.AddForeignKey(
                name: "FK_TramiteCasuistica_TipoCasuistica_Id_Casuistica",
                table: "TramiteCasuistica",
                column: "Id_Casuistica",
                principalTable: "TipoCasuistica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TramiteCasuistica_Tramite_Id_tramite",
                table: "TramiteCasuistica",
                column: "Id_tramite",
                principalTable: "Tramite",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TramiteCasuistica_TipoCasuistica_Id_Casuistica",
                table: "TramiteCasuistica");

            migrationBuilder.DropForeignKey(
                name: "FK_TramiteCasuistica_Tramite_Id_tramite",
                table: "TramiteCasuistica");

            migrationBuilder.DropIndex(
                name: "IX_TramiteCasuistica_Id_Casuistica",
                table: "TramiteCasuistica");
        }
    }
}
