using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherCollector.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weathers",
                columns: table => new
                {
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<TimeSpan>(nullable: false),
                    AirTemperature = table.Column<double>(nullable: true),
                    Humidity = table.Column<double>(nullable: true),
                    DewPoint = table.Column<double>(nullable: true),
                    Pressure = table.Column<int>(nullable: true),
                    WindDirection = table.Column<string>(nullable: true),
                    WindSpeed = table.Column<int>(nullable: true),
                    Overcast = table.Column<int>(nullable: true),
                    CloudBase = table.Column<int>(nullable: true),
                    HorizontalVisibility = table.Column<int>(nullable: true),
                    WeatherConditions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weathers", x => new { x.Date, x.Time });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weathers");
        }
    }
}
