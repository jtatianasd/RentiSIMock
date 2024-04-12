using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentiSI.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class RenombrarCampoEsResultadoEnTablaImpronta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EsResultado",
                table: "Impronta");

            migrationBuilder.AddColumn<string>(
                name: "EsResuelto",
                table: "Impronta",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EsResuelto",
                table: "Impronta");

            migrationBuilder.AddColumn<bool>(
                name: "EsResultado",
                table: "Impronta",
                type: "bit",
                nullable: true);
        }
    }
}
