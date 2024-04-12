using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentiSI.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class RenombrarKeyReasignacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Reasignacion",
                newName: "ReasignacionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReasignacionId",
                table: "Reasignacion",
                newName: "Id");
        }
    }
}
