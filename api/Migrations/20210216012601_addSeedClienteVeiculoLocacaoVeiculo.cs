using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace api.Migrations
{
    public partial class addSeedClienteVeiculoLocacaoVeiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ValorLocacao",
                table: "LocacaoVeiculos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Cpf", "DiaDeNascimento", "EnderecoId", "Nome", "PasswordHash", "PasswordSalt", "TipoDeUsuario" },
                values: new object[] { -2, "876.678.543.67", new DateTime(1992, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fulano da Silva", null, null, 1 });

            migrationBuilder.InsertData(
                table: "Veiculos",
                columns: new[] { "Id", "Ano", "EstaLocado", "Kilometragem", "LimitePortaMalas", "ModeloId", "Placa", "TipoDeCombustivel", "TipoDeVeiculo", "ValorHora" },
                values: new object[] { 1, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 0, 7, "XXX-0909", 0, 0, 45.950000000000003 });

            migrationBuilder.InsertData(
                table: "LocacaoVeiculos",
                columns: new[] { "Id", "ClienteId", "DataDevolucao", "DataLocacao", "TotalHoras", "ValorLocacao", "VeiculoId" },
                values: new object[] { -2, -2, new DateTime(2021, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 48, 91.900000000000006, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LocacaoVeiculos",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Veiculos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "ValorLocacao",
                table: "LocacaoVeiculos");
        }
    }
}
