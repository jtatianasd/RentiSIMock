using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentiSI.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarEntidadTramite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tramite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroPlaca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Financiacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Impronta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNegocio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRecepcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUsuarioRecibe = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaResultado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUsuarioResuelve = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TipificacionImpronta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipificacionCasuisticaImpronta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRevision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUsuarioRevision = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TipificacionTramiteRevision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoRevision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganismoTransito = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroGuia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipificacionCasuisticaRevision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaGestion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoGestion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUsuarioGestion = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaReasignacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUsuarioReasignacion = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tramite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tramite_AspNetUsers_IdUsuarioGestion",
                        column: x => x.IdUsuarioGestion,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tramite_AspNetUsers_IdUsuarioReasignacion",
                        column: x => x.IdUsuarioReasignacion,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tramite_AspNetUsers_IdUsuarioRecibe",
                        column: x => x.IdUsuarioRecibe,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tramite_AspNetUsers_IdUsuarioResuelve",
                        column: x => x.IdUsuarioResuelve,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tramite_AspNetUsers_IdUsuarioRevision",
                        column: x => x.IdUsuarioRevision,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tramite_IdUsuarioGestion",
                table: "Tramite",
                column: "IdUsuarioGestion");

            migrationBuilder.CreateIndex(
                name: "IX_Tramite_IdUsuarioReasignacion",
                table: "Tramite",
                column: "IdUsuarioReasignacion");

            migrationBuilder.CreateIndex(
                name: "IX_Tramite_IdUsuarioRecibe",
                table: "Tramite",
                column: "IdUsuarioRecibe");

            migrationBuilder.CreateIndex(
                name: "IX_Tramite_IdUsuarioResuelve",
                table: "Tramite",
                column: "IdUsuarioResuelve");

            migrationBuilder.CreateIndex(
                name: "IX_Tramite_IdUsuarioRevision",
                table: "Tramite",
                column: "IdUsuarioRevision");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tramite");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
