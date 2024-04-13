using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentiSI.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarLlavesForaneasATramiteCasuistica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TramiteCasuistica_CasuisticaId",
                table: "TramiteCasuistica",
                column: "CasuisticaId");

            migrationBuilder.AddForeignKey(
                name: "FK_TramiteCasuistica_Impronta_ImprontaId",
                table: "TramiteCasuistica",
                column: "ImprontaId",
                principalTable: "Impronta",
                principalColumn: "ImprontaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TramiteCasuistica_TipoCasuistica_CasuisticaId",
                table: "TramiteCasuistica",
                column: "CasuisticaId",
                principalTable: "TipoCasuistica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TramiteCasuistica_Impronta_ImprontaId",
                table: "TramiteCasuistica");

            migrationBuilder.DropForeignKey(
                name: "FK_TramiteCasuistica_TipoCasuistica_CasuisticaId",
                table: "TramiteCasuistica");

            migrationBuilder.DropIndex(
                name: "IX_TramiteCasuistica_CasuisticaId",
                table: "TramiteCasuistica");
        }
    }
}
