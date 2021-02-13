using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace api.Migrations
{
    public partial class ModUsuarioAbstract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Enderecos",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Operadores");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Clientes");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Operadores",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PassworkHash",
                table: "Operadores",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Clientes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PassworkHash",
                table: "Clientes",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Operadores");

            migrationBuilder.DropColumn(
                name: "PassworkHash",
                table: "Operadores");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "PassworkHash",
                table: "Clientes");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Operadores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Enderecos",
                columns: new[] { "Id", "Cep", "Cidade", "Complemento", "Estado", "Logradouro", "Numero" },
                values: new object[] { -1, "00000-000", "Belo Horizonte", null, "MG", "Rua Fulano de tal, Bairro Beltrano", 31 });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Cpf", "DiaDeNascimento", "EnderecoId", "Nome", "Senha", "TipoDeUsuario" },
                values: new object[] { -1, "111.111.111-11", new DateTime(2021, 2, 12, 20, 46, 50, 386, DateTimeKind.Local).AddTicks(6018), -1, "Primeiro Usuario", "senhateste@", 1 });
        }
    }
}
