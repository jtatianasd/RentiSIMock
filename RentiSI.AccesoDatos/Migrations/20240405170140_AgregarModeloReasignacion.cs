using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentiSI.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarModeloReasignacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reasignacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Tramite = table.Column<int>(type: "int", nullable: true),
                    FechaReasignacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUsuarioReasignacion = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reasignacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reasignacion_AspNetUsers_IdUsuarioReasignacion",
                        column: x => x.IdUsuarioReasignacion,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reasignacion_Tramite_Id_Tramite",
                        column: x => x.Id_Tramite,
                        principalTable: "Tramite",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reasignacion_Id_Tramite",
                table: "Reasignacion",
                column: "Id_Tramite");

            migrationBuilder.CreateIndex(
                name: "IX_Reasignacion_IdUsuarioReasignacion",
                table: "Reasignacion",
                column: "IdUsuarioReasignacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reasignacion");
        }
    }
}
