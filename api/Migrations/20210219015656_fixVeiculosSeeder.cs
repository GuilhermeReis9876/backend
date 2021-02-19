using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class fixVeiculosSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "Id", "Name" },
                values: new object[] { 9, "Hyundai" });

            migrationBuilder.UpdateData(
                table: "Modelos",
                keyColumn: "Id",
                keyValue: 16,
                column: "MarcaId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Modelos",
                keyColumn: "Id",
                keyValue: 10,
                column: "MarcaId",
                value: 9);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "Modelos",
                keyColumn: "Id",
                keyValue: 10,
                column: "MarcaId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Modelos",
                keyColumn: "Id",
                keyValue: 16,
                column: "MarcaId",
                value: 2);
        }
    }
}
