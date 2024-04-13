using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentiSI.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarTablasParaCasuistica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GestionCasuistica",
                columns: table => new
                {
                    GestionId = table.Column<int>(type: "int", nullable: false),
                    CasuisticaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GestionCasuistica", x => new { x.GestionId, x.CasuisticaId });
                    table.ForeignKey(
                        name: "FK_GestionCasuistica_Gestion_GestionId",
                        column: x => x.GestionId,
                        principalTable: "Gestion",
                        principalColumn: "GestionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GestionCasuistica_TipoCasuistica_CasuisticaId",
                        column: x => x.CasuisticaId,
                        principalTable: "TipoCasuistica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RevisionCasuistica",
                columns: table => new
                {
                    RevisionId = table.Column<int>(type: "int", nullable: false),
                    CasuisticaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevisionCasuistica", x => new { x.RevisionId, x.CasuisticaId });
                    table.ForeignKey(
                        name: "FK_RevisionCasuistica_Revision_RevisionId",
                        column: x => x.RevisionId,
                        principalTable: "Revision",
                        principalColumn: "RevisionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RevisionCasuistica_TipoCasuistica_CasuisticaId",
                        column: x => x.CasuisticaId,
                        principalTable: "TipoCasuistica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GestionCasuistica_CasuisticaId",
                table: "GestionCasuistica",
                column: "CasuisticaId");

            migrationBuilder.CreateIndex(
                name: "IX_RevisionCasuistica_CasuisticaId",
                table: "RevisionCasuistica",
                column: "CasuisticaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GestionCasuistica");

            migrationBuilder.DropTable(
                name: "RevisionCasuistica");
        }
    }
}
