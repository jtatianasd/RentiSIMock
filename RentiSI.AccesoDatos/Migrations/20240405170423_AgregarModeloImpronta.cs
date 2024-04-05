using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentiSI.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarModeloImpronta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Impronta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Tramite = table.Column<int>(type: "int", nullable: true),
                    TipificacionImpronta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipificacionCasuisticaImpronta = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Impronta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Impronta_Tramite_Id_Tramite",
                        column: x => x.Id_Tramite,
                        principalTable: "Tramite",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Impronta_Id_Tramite",
                table: "Impronta",
                column: "Id_Tramite");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Impronta");
        }
    }
}
