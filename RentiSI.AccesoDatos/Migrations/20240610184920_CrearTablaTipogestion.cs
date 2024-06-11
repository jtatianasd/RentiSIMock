using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentiSI.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablaTipogestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
            name: "TipoGestion",
            columns: table => new
            {
                TramiteId = table.Column<int>(type: "int", nullable: false),
                TipoGestionId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TipoGestion", x => new { x.TramiteId, x.TipoGestionId });
                table.ForeignKey(
                    name: "FK_TipoGestion_Tramite_TramiteId",
                    column: x => x.TramiteId,
                    principalTable: "Tramite",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_TipoGestion_TipoCasuistica_TipoGestionId",
                    column: x => x.TipoGestionId,
                    principalTable: "TipoCasuistica",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

            migrationBuilder.CreateIndex(
                name: "IX_TipoGestion_TipoGestionId",
                table: "TipoGestion",
                column: "TipoGestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
            name: "TipoGestion");
        }
    }
}
