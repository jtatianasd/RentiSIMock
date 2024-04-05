using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentiSI.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarModeloRevision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Revision",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Tramite = table.Column<int>(type: "int", nullable: true),
                    IdUsuarioRevision = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TipificacionTramiteRevision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoRevision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipificacionCasuisticaRevision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganismoTransito = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroGuia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revision", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Revision_AspNetUsers_IdUsuarioRevision",
                        column: x => x.IdUsuarioRevision,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Revision_Tramite_Id_Tramite",
                        column: x => x.Id_Tramite,
                        principalTable: "Tramite",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Revision_Id_Tramite",
                table: "Revision",
                column: "Id_Tramite");

            migrationBuilder.CreateIndex(
                name: "IX_Revision_IdUsuarioRevision",
                table: "Revision",
                column: "IdUsuarioRevision");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Revision");
        }
    }
}
