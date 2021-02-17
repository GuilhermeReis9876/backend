using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class CorrecaoDeOperador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Operadores",
                keyColumn: "Id",
                keyValue: 1,
                column: "Matricula",
                value: "123456");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Operadores",
                keyColumn: "Id",
                keyValue: 1,
                column: "Matricula",
                value: null);
        }
    }
}
