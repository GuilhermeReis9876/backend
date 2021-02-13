using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class CorrigindoColunaHash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PassworkHash",
                table: "Operadores",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "PassworkHash",
                table: "Clientes",
                newName: "PasswordHash");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Operadores",
                newName: "PassworkHash");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Clientes",
                newName: "PassworkHash");
        }
    }
}
