using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentiSI.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class EliminarCampoOrganismoDeTransitoDeImpronta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Impronta_OrganismosDeTransito_OrganismoDeTransitoId",
                table: "Impronta");

            migrationBuilder.DropIndex(
                name: "IX_Impronta_OrganismoDeTransitoId",
                table: "Impronta");

            migrationBuilder.DropColumn(
                name: "OrganismoDeTransitoId",
                table: "Impronta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
