using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.DataAccess.Migrations
{
    public partial class AddedRatio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityRatio",
                table: "Cities");

            migrationBuilder.AddColumn<double>(
                name: "Ratio",
                table: "Cities",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ratio",
                table: "Cities");

            migrationBuilder.AddColumn<double>(
                name: "CityRatio",
                table: "Cities",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
