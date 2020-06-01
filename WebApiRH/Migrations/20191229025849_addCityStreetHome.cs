using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiRH.Migrations
{
    public partial class addCityStreetHome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Home");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Home",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HomeNumber",
                table: "Home",
                type: "nvarchar(5)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Home",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "HomeNumber",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Home");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Home",
                type: "nvarchar(200)",
                nullable: false,
                defaultValue: "");
        }
    }
}
