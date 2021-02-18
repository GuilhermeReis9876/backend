using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace api.Migrations
{
    public partial class NewData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LocacaoVeiculos",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Cpf", "DiaDeNascimento", "EnderecoId", "Nome", "PasswordHash", "PasswordSalt", "TipoDeUsuario" },
                values: new object[] { 1, "063.923.720-75", new DateTime(1992, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fulano da Silva Cliente", null, null, 1 });

            migrationBuilder.InsertData(
                table: "Operadores",
                columns: new[] { "Id", "DiaDeNascimento", "EnderecoId", "Matricula", "Nome", "PasswordHash", "PasswordSalt", "TipoDeUsuario" },
                values: new object[] { 1, new DateTime(1990, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Beltrano da Silva Operador", null, null, 0 });

            migrationBuilder.InsertData(
                table: "LocacaoVeiculos",
                columns: new[] { "Id", "ClienteId", "DataDevolucao", "DataLocacao", "Status", "TotalHoras", "ValorLocacao", "VeiculoId" },
                values: new object[] { 1, 1, new DateTime(2021, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 48, 91.900000000000006, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LocacaoVeiculos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Operadores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Cpf", "DiaDeNascimento", "EnderecoId", "Nome", "PasswordHash", "PasswordSalt", "TipoDeUsuario" },
                values: new object[] { -2, "876.678.543.67", new DateTime(1992, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fulano da Silva", null, null, 1 });

            migrationBuilder.InsertData(
                table: "LocacaoVeiculos",
                columns: new[] { "Id", "ClienteId", "DataDevolucao", "DataLocacao", "Status", "TotalHoras", "ValorLocacao", "VeiculoId" },
                values: new object[] { -2, -2, new DateTime(2021, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 48, 91.900000000000006, 1 });
        }
    }
}
