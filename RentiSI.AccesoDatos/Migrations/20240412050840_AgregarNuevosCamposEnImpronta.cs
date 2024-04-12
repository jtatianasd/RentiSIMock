using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentiSI.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarNuevosCamposEnImpronta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipificacionCasuisticaImpronta",
                table: "Impronta",
                newName: "Observaciones");

            migrationBuilder.AddColumn<bool>(
                name: "EsResultado",
                table: "Impronta",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganismoDeTransitoId",
                table: "Impronta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Impronta_OrganismoDeTransitoId",
                table: "Impronta",
                column: "OrganismoDeTransitoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Impronta_OrganismosDeTransito_OrganismoDeTransitoId",
                table: "Impronta",
                column: "OrganismoDeTransitoId",
                principalTable: "OrganismosDeTransito",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Impronta_OrganismosDeTransito_OrganismoDeTransitoId",
                table: "Impronta");

            migrationBuilder.DropIndex(
                name: "IX_Impronta_OrganismoDeTransitoId",
                table: "Impronta");

            migrationBuilder.DropColumn(
                name: "EsResultado",
                table: "Impronta");

            migrationBuilder.DropColumn(
                name: "OrganismoDeTransitoId",
                table: "Impronta");

            migrationBuilder.RenameColumn(
                name: "Observaciones",
                table: "Impronta",
                newName: "TipificacionCasuisticaImpronta");
        }
    }
}
