using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentiSI.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class ModificarGestionTramite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gestion_AspNetUsers_IdUsuarioResuelve",
                table: "Gestion");

            migrationBuilder.DropForeignKey(
                name: "FK_Gestion_TipoDetalleEstado_IdDetalleEstado",
                table: "Gestion");

            migrationBuilder.DropIndex(
                name: "IX_Gestion_IdUsuarioResuelve",
                table: "Gestion");

            migrationBuilder.DropColumn(
                name: "IdUsuarioResuelve",
                table: "Gestion");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaNegocio",
                table: "Tramite",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "IdDetalleEstado",
                table: "Gestion",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Gestion_TipoDetalleEstado_IdDetalleEstado",
                table: "Gestion",
                column: "IdDetalleEstado",
                principalTable: "TipoDetalleEstado",
                principalColumn: "IdTipoDetalleEstado",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gestion_TipoDetalleEstado_IdDetalleEstado",
                table: "Gestion");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaNegocio",
                table: "Tramite",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdDetalleEstado",
                table: "Gestion",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "IdUsuarioResuelve",
                table: "Gestion",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gestion_IdUsuarioResuelve",
                table: "Gestion",
                column: "IdUsuarioResuelve");

            migrationBuilder.AddForeignKey(
                name: "FK_Gestion_AspNetUsers_IdUsuarioResuelve",
                table: "Gestion",
                column: "IdUsuarioResuelve",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gestion_TipoDetalleEstado_IdDetalleEstado",
                table: "Gestion",
                column: "IdDetalleEstado",
                principalTable: "TipoDetalleEstado",
                principalColumn: "IdTipoDetalleEstado");
        }
    }
}
