using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentiSI.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class EliminarCamposRevision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoRevision",
                table: "Revision");

            migrationBuilder.DropColumn(
                name: "OrganismoTransito",
                table: "Revision");

            migrationBuilder.DropColumn(
                name: "TipificacionCasuisticaRevision",
                table: "Revision");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EstadoRevision",
                table: "Revision",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrganismoTransito",
                table: "Revision",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipificacionCasuisticaRevision",
                table: "Revision",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
