using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Migrant.App.Persistencia.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ciudad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCiudad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePais = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SituacionLaboral",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoSituacionLaboral = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituacionLaboral", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDoc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Migrantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: true),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaisOrigenId = table.Column<int>(type: "int", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTelefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionActual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CiudadId = table.Column<int>(type: "int", nullable: true),
                    SituacionLaboralId = table.Column<int>(type: "int", nullable: true),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Migrantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Migrantes_Ciudad_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Migrantes_Pais_PaisOrigenId",
                        column: x => x.PaisOrigenId,
                        principalTable: "Pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Migrantes_SituacionLaboral_SituacionLaboralId",
                        column: x => x.SituacionLaboralId,
                        principalTable: "SituacionLaboral",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Migrantes_TipoDoc_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalTable: "TipoDoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Migrantes_CiudadId",
                table: "Migrantes",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_Migrantes_PaisOrigenId",
                table: "Migrantes",
                column: "PaisOrigenId");

            migrationBuilder.CreateIndex(
                name: "IX_Migrantes_SituacionLaboralId",
                table: "Migrantes",
                column: "SituacionLaboralId");

            migrationBuilder.CreateIndex(
                name: "IX_Migrantes_TipoDocumentoId",
                table: "Migrantes",
                column: "TipoDocumentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Migrantes");

            migrationBuilder.DropTable(
                name: "Ciudad");

            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.DropTable(
                name: "SituacionLaboral");

            migrationBuilder.DropTable(
                name: "TipoDoc");
        }
    }
}
