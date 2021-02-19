using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class modVeiculoAddSeederVeiculos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Veiculos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "Veiculos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Motor",
                table: "Veiculos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "Chevrolet" },
                    { 4, "Nissan" },
                    { 5, "Ford" },
                    { 6, "Toyota" },
                    { 7, "Jeep" },
                    { 8, "BMW" }
                });

            migrationBuilder.UpdateData(
                table: "Modelos",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Gol");

            migrationBuilder.InsertData(
                table: "Modelos",
                columns: new[] { "Id", "MarcaId", "Name" },
                values: new object[,]
                {
                    { 9, 1, "Moby" },
                    { 11, 2, "Saveiro" },
                    { 12, 2, "Virtus" },
                    { 15, 2, "Polo" },
                    { 16, 2, "Toro" },
                    { 20, 2, "Golf" }
                });

            migrationBuilder.InsertData(
                table: "Veiculos",
                columns: new[] { "Id", "Ano", "EstaLocado", "Imagem", "Kilometragem", "LimitePortaMalas", "ModeloId", "Motor", "Placa", "TipoDeCombustivel", "TipoDeVeiculo", "ValorHora" },
                values: new object[,]
                {
                    { 3, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "https://localiza.vercel.app/utils/img/gol.png", 0, 210, 5, "1.0", "FFF-5256", 3, 0, 5.25 },
                    { 6, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "https://localiza.vercel.app/utils/img/voyage.png", 0, 180, 7, "1.0", "PUT-4971", 3, 0, 7.21 }
                });

            migrationBuilder.InsertData(
                table: "Modelos",
                columns: new[] { "Id", "MarcaId", "Name" },
                values: new object[,]
                {
                    { 10, 3, "HB-20" },
                    { 13, 4, "Versa" },
                    { 14, 5, "Eco Sport" },
                    { 17, 6, "Hylux" },
                    { 18, 7, "Compass" },
                    { 19, 8, "X1" }
                });

            migrationBuilder.InsertData(
                table: "Veiculos",
                columns: new[] { "Id", "Ano", "EstaLocado", "Imagem", "Kilometragem", "LimitePortaMalas", "ModeloId", "Motor", "Placa", "TipoDeCombustivel", "TipoDeVeiculo", "ValorHora" },
                values: new object[,]
                {
                    { 2, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "https://localiza.vercel.app/utils/img/moby.png", 0, 200, 9, "1.0", "PUA-1049", 3, 0, 4.1200000000000001 },
                    { 5, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "https://localiza.vercel.app/utils/img/saveiro.png", 0, 220, 11, "1.0", "OMF-5162", 3, 0, 6.3200000000000003 },
                    { 7, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "https://localiza.vercel.app/utils/img/virtus.png", 0, 220, 12, "1.4", "JKG-4971", 3, 1, 8.3200000000000003 },
                    { 10, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "https://localiza.vercel.app/utils/img/polo.png", 0, 250, 15, "1.4", "ZAQ-4971", 3, 1, 8.9800000000000004 },
                    { 11, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "https://localiza.vercel.app/utils/img/toro.png", 0, 250, 16, "2.0", "EFW-4971", 2, 1, 8.9800000000000004 },
                    { 15, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "https://localiza.vercel.app/utils/img/golf.png", 0, 250, 20, "1.4", "YHT-1234", 3, 2, 9.2100000000000009 }
                });

            migrationBuilder.InsertData(
                table: "Veiculos",
                columns: new[] { "Id", "Ano", "EstaLocado", "Imagem", "Kilometragem", "LimitePortaMalas", "ModeloId", "Motor", "Placa", "TipoDeCombustivel", "TipoDeVeiculo", "ValorHora" },
                values: new object[,]
                {
                    { 4, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "https://localiza.vercel.app/utils/img/hb20.png", 0, 180, 10, "1.0", "HOK-5912", 3, 0, 6.3200000000000003 },
                    { 8, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "https://localiza.vercel.app/utils/img/versa.png", 0, 220, 13, "2.0", "UIO-4971", 3, 1, 8.9800000000000004 },
                    { 9, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "https://localiza.vercel.app/utils/img/ecosport.png", 0, 300, 14, "1.6", "MNK-4971", 3, 1, 8.9800000000000004 },
                    { 12, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "https://localiza.vercel.app/utils/img/hylux.png", 0, 400, 17, "3.2", "PDL-4971", 2, 2, 9.5600000000000005 },
                    { 13, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "https://localiza.vercel.app/utils/img/compass.png", 0, 350, 18, "2.0", "YHT-4515", 3, 2, 9.5600000000000005 },
                    { 14, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "https://localiza.vercel.app/utils/img/x1.png", 0, 380, 19, "2.2", "YHT-6723", 0, 2, 12.98 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Veiculos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Veiculos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Veiculos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Veiculos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Veiculos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Veiculos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Veiculos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Veiculos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Veiculos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Veiculos",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Veiculos",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Veiculos",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Veiculos",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Veiculos",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Modelos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Modelos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Modelos",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Modelos",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Modelos",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Modelos",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Modelos",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Modelos",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Modelos",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Modelos",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Modelos",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Modelos",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "Motor",
                table: "Veiculos");

            migrationBuilder.UpdateData(
                table: "Modelos",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Gol - Gen 5");

            migrationBuilder.InsertData(
                table: "Veiculos",
                columns: new[] { "Id", "Ano", "EstaLocado", "Kilometragem", "LimitePortaMalas", "ModeloId", "Placa", "TipoDeCombustivel", "TipoDeVeiculo", "ValorHora" },
                values: new object[] { 1, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, 0, 7, "XXX-0909", 0, 0, 45.950000000000003 });
        }
    }
}
