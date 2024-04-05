using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentiSI.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarModeloGestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Tramite = table.Column<int>(type: "int", nullable: true),
                    FechaGestion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoGestion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUsuarioGestion = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FechaResultado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUsuarioResuelve = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gestion_AspNetUsers_IdUsuarioGestion",
                        column: x => x.IdUsuarioGestion,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Gestion_AspNetUsers_IdUsuarioResuelve",
                        column: x => x.IdUsuarioResuelve,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Gestion_Tramite_Id_Tramite",
                        column: x => x.Id_Tramite,
                        principalTable: "Tramite",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gestion_Id_Tramite",
                table: "Gestion",
                column: "Id_Tramite");

            migrationBuilder.CreateIndex(
                name: "IX_Gestion_IdUsuarioGestion",
                table: "Gestion",
                column: "IdUsuarioGestion");

            migrationBuilder.CreateIndex(
                name: "IX_Gestion_IdUsuarioResuelve",
                table: "Gestion",
                column: "IdUsuarioResuelve");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gestion");
        }
    }
}
