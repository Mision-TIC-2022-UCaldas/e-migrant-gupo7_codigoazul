using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Migrant.App.Persistencia.Migrations
{
    public partial class InicialCorreccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Migrante_Ciudad_CiudadId",
                table: "Migrante");

            migrationBuilder.DropForeignKey(
                name: "FK_Migrante_Pais_PaisOrigenId",
                table: "Migrante");

            migrationBuilder.DropForeignKey(
                name: "FK_Migrante_SituacionLaboral_SituacionLaboralId",
                table: "Migrante");

            migrationBuilder.DropForeignKey(
                name: "FK_Migrante_TipoDoc_TipoDocumentoId",
                table: "Migrante");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Migrante",
                table: "Migrante");

            migrationBuilder.RenameTable(
                name: "Migrante",
                newName: "Migrantes");

            migrationBuilder.RenameIndex(
                name: "IX_Migrante_TipoDocumentoId",
                table: "Migrantes",
                newName: "IX_Migrantes_TipoDocumentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Migrante_SituacionLaboralId",
                table: "Migrantes",
                newName: "IX_Migrantes_SituacionLaboralId");

            migrationBuilder.RenameIndex(
                name: "IX_Migrante_PaisOrigenId",
                table: "Migrantes",
                newName: "IX_Migrantes_PaisOrigenId");

            migrationBuilder.RenameIndex(
                name: "IX_Migrante_CiudadId",
                table: "Migrantes",
                newName: "IX_Migrantes_CiudadId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Migrantes",
                table: "Migrantes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Migrantes_Ciudad_CiudadId",
                table: "Migrantes",
                column: "CiudadId",
                principalTable: "Ciudad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Migrantes_Pais_PaisOrigenId",
                table: "Migrantes",
                column: "PaisOrigenId",
                principalTable: "Pais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Migrantes_SituacionLaboral_SituacionLaboralId",
                table: "Migrantes",
                column: "SituacionLaboralId",
                principalTable: "SituacionLaboral",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Migrantes_TipoDoc_TipoDocumentoId",
                table: "Migrantes",
                column: "TipoDocumentoId",
                principalTable: "TipoDoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Migrantes_Ciudad_CiudadId",
                table: "Migrantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Migrantes_Pais_PaisOrigenId",
                table: "Migrantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Migrantes_SituacionLaboral_SituacionLaboralId",
                table: "Migrantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Migrantes_TipoDoc_TipoDocumentoId",
                table: "Migrantes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Migrantes",
                table: "Migrantes");

            migrationBuilder.RenameTable(
                name: "Migrantes",
                newName: "Migrante");

            migrationBuilder.RenameIndex(
                name: "IX_Migrantes_TipoDocumentoId",
                table: "Migrante",
                newName: "IX_Migrante_TipoDocumentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Migrantes_SituacionLaboralId",
                table: "Migrante",
                newName: "IX_Migrante_SituacionLaboralId");

            migrationBuilder.RenameIndex(
                name: "IX_Migrantes_PaisOrigenId",
                table: "Migrante",
                newName: "IX_Migrante_PaisOrigenId");

            migrationBuilder.RenameIndex(
                name: "IX_Migrantes_CiudadId",
                table: "Migrante",
                newName: "IX_Migrante_CiudadId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Migrante",
                table: "Migrante",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Migrante_Ciudad_CiudadId",
                table: "Migrante",
                column: "CiudadId",
                principalTable: "Ciudad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Migrante_Pais_PaisOrigenId",
                table: "Migrante",
                column: "PaisOrigenId",
                principalTable: "Pais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Migrante_SituacionLaboral_SituacionLaboralId",
                table: "Migrante",
                column: "SituacionLaboralId",
                principalTable: "SituacionLaboral",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Migrante_TipoDoc_TipoDocumentoId",
                table: "Migrante",
                column: "TipoDocumentoId",
                principalTable: "TipoDoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
