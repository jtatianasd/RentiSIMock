using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentiSI.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCamposATablaImpronta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaResultadoImpronta",
                table: "Impronta",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IdUsuarioResuelveImpronta",
                table: "Impronta",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Impronta_IdUsuarioResuelveImpronta",
                table: "Impronta",
                column: "IdUsuarioResuelveImpronta");

            migrationBuilder.AddForeignKey(
                name: "FK_Impronta_AspNetUsers_IdUsuarioResuelveImpronta",
                table: "Impronta",
                column: "IdUsuarioResuelveImpronta",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Impronta_AspNetUsers_IdUsuarioResuelveImpronta",
                table: "Impronta");

            migrationBuilder.DropIndex(
                name: "IX_Impronta_IdUsuarioResuelveImpronta",
                table: "Impronta");

            migrationBuilder.DropColumn(
                name: "FechaResultadoImpronta",
                table: "Impronta");

            migrationBuilder.DropColumn(
                name: "IdUsuarioResuelveImpronta",
                table: "Impronta");
        }
    }
}
