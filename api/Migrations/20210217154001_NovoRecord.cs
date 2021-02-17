using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class NovoRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "LocacaoVeiculos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "CheckListInicial",
                table: "CheckLists",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "LocacaoVeiculos");

            migrationBuilder.DropColumn(
                name: "CheckListInicial",
                table: "CheckLists");
        }
    }
}
