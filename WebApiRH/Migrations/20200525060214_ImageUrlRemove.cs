using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiRH.Migrations
{
    public partial class ImageUrlRemove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Removed",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "UrlRemove",
                table: "Images",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlRemove",
                table: "Images");

            migrationBuilder.AddColumn<bool>(
                name: "Removed",
                table: "Images",
                nullable: false,
                defaultValue: false);
        }
    }
}
