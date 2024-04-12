using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentiSI.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class RenombrarKeyGestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Gestion",
                newName: "GestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GestionId",
                table: "Gestion",
                newName: "Id");
        }
    }
}
