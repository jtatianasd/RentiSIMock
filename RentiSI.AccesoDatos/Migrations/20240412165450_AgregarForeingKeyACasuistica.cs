using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentiSI.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarForeingKeyACasuistica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_TramiteCasuistica_Impronta_Id_tramite",
                table: "TramiteCasuistica",
                column: "Id_tramite",
                principalTable: "Impronta",
                principalColumn: "ImprontaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TramiteCasuistica_Revision_Id_tramite",
                table: "TramiteCasuistica",
                column: "Id_tramite",
                principalTable: "Revision",
                principalColumn: "RevisionId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TramiteCasuistica_Impronta_Id_tramite",
                table: "TramiteCasuistica");

            migrationBuilder.DropForeignKey(
                name: "FK_TramiteCasuistica_Revision_Id_tramite",
                table: "TramiteCasuistica");
        }
    }
}
