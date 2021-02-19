using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class fixDataLocacaoSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LocacaoVeiculos",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataDevolucao",
                value: new DateTime(2021, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LocacaoVeiculos",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataDevolucao",
                value: new DateTime(2021, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
