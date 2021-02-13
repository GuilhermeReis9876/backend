using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class AlterandoColunas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocacaoVeiculos_CheckLists_CheckListId",
                table: "LocacaoVeiculos");

            migrationBuilder.DropIndex(
                name: "IX_LocacaoVeiculos_CheckListId",
                table: "LocacaoVeiculos");

            migrationBuilder.DropColumn(
                name: "CheckListId",
                table: "LocacaoVeiculos");

            migrationBuilder.DropColumn(
                name: "CheckelistId",
                table: "LocacaoVeiculos");

            migrationBuilder.DropColumn(
                name: "EstaLocado",
                table: "LocacaoVeiculos");

            migrationBuilder.AddColumn<bool>(
                name: "EstaLocado",
                table: "Veiculos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LocacaoVeiculoId",
                table: "CheckLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OperadorId",
                table: "CheckLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CheckLists_LocacaoVeiculoId",
                table: "CheckLists",
                column: "LocacaoVeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckLists_OperadorId",
                table: "CheckLists",
                column: "OperadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckLists_LocacaoVeiculos_LocacaoVeiculoId",
                table: "CheckLists",
                column: "LocacaoVeiculoId",
                principalTable: "LocacaoVeiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckLists_Operadores_OperadorId",
                table: "CheckLists",
                column: "OperadorId",
                principalTable: "Operadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckLists_LocacaoVeiculos_LocacaoVeiculoId",
                table: "CheckLists");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckLists_Operadores_OperadorId",
                table: "CheckLists");

            migrationBuilder.DropIndex(
                name: "IX_CheckLists_LocacaoVeiculoId",
                table: "CheckLists");

            migrationBuilder.DropIndex(
                name: "IX_CheckLists_OperadorId",
                table: "CheckLists");

            migrationBuilder.DropColumn(
                name: "EstaLocado",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "LocacaoVeiculoId",
                table: "CheckLists");

            migrationBuilder.DropColumn(
                name: "OperadorId",
                table: "CheckLists");

            migrationBuilder.AddColumn<int>(
                name: "CheckListId",
                table: "LocacaoVeiculos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CheckelistId",
                table: "LocacaoVeiculos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "EstaLocado",
                table: "LocacaoVeiculos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_LocacaoVeiculos_CheckListId",
                table: "LocacaoVeiculos",
                column: "CheckListId");

            migrationBuilder.AddForeignKey(
                name: "FK_LocacaoVeiculos_CheckLists_CheckListId",
                table: "LocacaoVeiculos",
                column: "CheckListId",
                principalTable: "CheckLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
