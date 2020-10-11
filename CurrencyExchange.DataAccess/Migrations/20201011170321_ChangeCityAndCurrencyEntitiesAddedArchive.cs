using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.DataAccess.Migrations
{
    public partial class ChangeCityAndCurrencyEntitiesAddedArchive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Rate",
                table: "Currencies",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CityRatio",
                table: "Cities",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "CurrenciesArchive",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<double>(nullable: false),
                    CurrencyName = table.Column<string>(nullable: true),
                    CurrencyCode = table.Column<string>(nullable: true),
                    CurrencySymbol = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ChangeTime = table.Column<DateTime>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: true),
                    DeleteTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrenciesArchive", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrenciesArchive_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurrenciesArchive_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrenciesArchive_CityId",
                table: "CurrenciesArchive",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrenciesArchive_CurrencyId",
                table: "CurrenciesArchive",
                column: "CurrencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrenciesArchive");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "CityRatio",
                table: "Cities");
        }
    }
}
