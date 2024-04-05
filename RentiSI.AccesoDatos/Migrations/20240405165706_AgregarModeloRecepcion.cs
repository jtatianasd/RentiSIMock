using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentiSI.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarModeloRecepcion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recepcion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Tramite = table.Column<int>(type: "int", nullable: true),
                    FechaRecepcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUsuarioRecepcion = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recepcion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recepcion_AspNetUsers_IdUsuarioRecepcion",
                        column: x => x.IdUsuarioRecepcion,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Recepcion_Tramite_Id_Tramite",
                        column: x => x.Id_Tramite,
                        principalTable: "Tramite",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recepcion_Id_Tramite",
                table: "Recepcion",
                column: "Id_Tramite");

            migrationBuilder.CreateIndex(
                name: "IX_Recepcion_IdUsuarioRecepcion",
                table: "Recepcion",
                column: "IdUsuarioRecepcion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recepcion");
        }
    }
}
