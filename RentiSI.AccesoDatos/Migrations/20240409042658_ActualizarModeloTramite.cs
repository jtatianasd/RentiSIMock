using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentiSI.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarModeloTramite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tramite_OrganismosDeTransito_OrganismoDeTransito",
                table: "Tramite");

            migrationBuilder.DropIndex(
                name: "IX_Tramite_OrganismoDeTransito",
                table: "Tramite");

            migrationBuilder.DropColumn(
                name: "OrganismoDeTransito",
                table: "Tramite");

            migrationBuilder.AddColumn<int>(
                name: "OrganismoDeTransitoId",
                table: "Tramite",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tramite_OrganismoDeTransitoId",
                table: "Tramite",
                column: "OrganismoDeTransitoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tramite_OrganismosDeTransito_OrganismoDeTransitoId",
                table: "Tramite",
                column: "OrganismoDeTransitoId",
                principalTable: "OrganismosDeTransito",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tramite_OrganismosDeTransito_OrganismoDeTransitoId",
                table: "Tramite");

            migrationBuilder.DropIndex(
                name: "IX_Tramite_OrganismoDeTransitoId",
                table: "Tramite");

            migrationBuilder.DropColumn(
                name: "OrganismoDeTransitoId",
                table: "Tramite");

            migrationBuilder.AddColumn<int>(
                name: "OrganismoDeTransito",
                table: "Tramite",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tramite_OrganismoDeTransito",
                table: "Tramite",
                column: "OrganismoDeTransito");

            migrationBuilder.AddForeignKey(
                name: "FK_Tramite_OrganismosDeTransito_OrganismoDeTransito",
                table: "Tramite",
                column: "OrganismoDeTransito",
                principalTable: "OrganismosDeTransito",
                principalColumn: "Id");
        }
    }
}
