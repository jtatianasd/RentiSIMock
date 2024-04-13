using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentiSI.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class RemoveForeingKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TramiteCasuistica_Impronta_Id_tramite",
                table: "TramiteCasuistica");

            migrationBuilder.DropForeignKey(
                name: "FK_TramiteCasuistica_Revision_Id_tramite",
                table: "TramiteCasuistica");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TramiteCasuistica_Id_Casuistica",
                table: "TramiteCasuistica",
                column: "Id_Casuistica");

            migrationBuilder.AddForeignKey(
                name: "FK_TramiteCasuistica_Impronta_Id_tramite",
                table: "TramiteCasuistica",
                column: "Id_tramite",
                principalTable: "Impronta",
                principalColumn: "ImprontaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TramiteCasuistica_Revision_Id_tramite",
                table: "TramiteCasuistica",
                column: "Id_tramite",
                principalTable: "Revision",
                principalColumn: "RevisionId",
                onDelete: ReferentialAction.Cascade);

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
    }
}
