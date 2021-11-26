using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Migrant.App.Persistencia.Migrations
{
    public partial class InicialCorreccionMigrante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "rol",
                table: "Migrantes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "rol",
                table: "Migrantes");
        }
    }
}
