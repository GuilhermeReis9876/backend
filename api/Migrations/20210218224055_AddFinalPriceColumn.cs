using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class AddFinalPriceColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ValorFinal",
                table: "LocacaoVeiculos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorFinal",
                table: "LocacaoVeiculos");
        }
    }
}
