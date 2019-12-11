using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiRH.Migrations
{
    public partial class dbfix3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Images");

            migrationBuilder.AlterColumn<string>(
                name: "yourOption",
                table: "Voting",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Voting",
                type: "nvarchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "User",
                type: "Nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "LocalGroup",
                type: "nvarchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Home",
                type: "nvarchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "GroupChat",
                type: "nvarchar(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(MAX)");

            migrationBuilder.AlterColumn<string>(
                name: "Option",
                table: "Answer",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Reviews",
                table: "AdvertsReview",
                type: "nvarchar(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(MAX)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Advert",
                type: "nvarchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Advert",
                type: "nvarchar(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(MAX)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "yourOption",
                table: "Voting",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Voting",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "User",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Nvarchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "LocalGroup",
                type: "varchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Images",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Home",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "GroupChat",
                type: "varchar(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)");

            migrationBuilder.AlterColumn<string>(
                name: "Option",
                table: "Answer",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Reviews",
                table: "AdvertsReview",
                type: "varchar(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Advert",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Advert",
                type: "varchar(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)");
        }
    }
}
