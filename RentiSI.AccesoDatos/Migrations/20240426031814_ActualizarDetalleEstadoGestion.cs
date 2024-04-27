using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentiSI.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarDetalleEstadoGestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
            name: "IdDetalleEstado",
            table: "Gestion",
            type: "int",
            nullable: true,
            defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
        name: "IdDetalleEstado",
        table: "Gestion",
        type: "int",
        nullable: false,
        defaultValue: 0);
        }
    }
}
