using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentiSI.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class RenombrarTablaTramiteCasuistica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id_Casuistica",
                table: "TramiteCasuistica",
                newName: "CasuisticaId");

            migrationBuilder.RenameColumn(
                name: "Id_tramite",
                table: "TramiteCasuistica",
                newName: "ImprontaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CasuisticaId",
                table: "TramiteCasuistica",
                newName: "Id_Casuistica");

            migrationBuilder.RenameColumn(
                name: "ImprontaId",
                table: "TramiteCasuistica",
                newName: "Id_tramite");
        }
    }
}
