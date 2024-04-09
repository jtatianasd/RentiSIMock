using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentiSI.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarModeloOrganismoDeTransito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganismoDeTransito",
                table: "Tramite",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrganismosDeTransito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Municipio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganismosDeTransito", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tramite_OrganismosDeTransito_OrganismoDeTransito",
                table: "Tramite");

            migrationBuilder.DropTable(
                name: "OrganismosDeTransito");

            migrationBuilder.DropIndex(
                name: "IX_Tramite_OrganismoDeTransito",
                table: "Tramite");

            migrationBuilder.DropColumn(
                name: "OrganismoDeTransito",
                table: "Tramite");
        }
    }
}
