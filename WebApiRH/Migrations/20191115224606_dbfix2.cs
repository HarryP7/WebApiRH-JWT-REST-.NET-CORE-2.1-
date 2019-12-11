using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiRH.Migrations
{
    public partial class dbfix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "LocalGroup",
                type: "varchar(200)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "LocalGroup");
        }
    }
}
