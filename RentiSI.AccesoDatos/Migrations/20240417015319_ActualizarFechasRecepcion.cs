using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentiSI.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarFechasRecepcion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
              name: "FechaRecepcion",
              table: "Recepcion",
              type: "datetime2",
              nullable: true,
              oldClrType: typeof(string),
              oldType: "nvarchar(max)",
              oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
               name: "FechaRecepcion",
               table: "Recepcion",
               type: "nvarchar(max)",
               nullable: true,
               oldClrType: typeof(DateTime),
               oldType: "datetime2",
               oldNullable: true);
        }
    }
}
