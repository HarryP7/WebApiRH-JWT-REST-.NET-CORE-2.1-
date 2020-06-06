using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiRH.Migrations
{
    public partial class fixDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "LocalGroup");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Advert");

            migrationBuilder.DropColumn(
                name: "TotalVotes",
                table: "Advert");

            migrationBuilder.RenameColumn(
                name: "GenderId",
                table: "User",
                newName: "Fk_Gender");

            migrationBuilder.AddColumn<int>(
                name: "TotalVotes",
                table: "Voting",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Fk_Author",
                table: "Advert",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Advert_Fk_Author",
                table: "Advert",
                column: "Fk_Author");

            migrationBuilder.AddForeignKey(
                name: "FK_Advert_User_Fk_Author",
                table: "Advert",
                column: "Fk_Author",
                principalTable: "User",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advert_User_Fk_Author",
                table: "Advert");

            migrationBuilder.DropIndex(
                name: "IX_Advert_Fk_Author",
                table: "Advert");

            migrationBuilder.DropColumn(
                name: "TotalVotes",
                table: "Voting");

            migrationBuilder.DropColumn(
                name: "Fk_Author",
                table: "Advert");

            migrationBuilder.RenameColumn(
                name: "Fk_Gender",
                table: "User",
                newName: "GenderId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "User",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "LocalGroup",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Home",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Advert",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalVotes",
                table: "Advert",
                nullable: false,
                defaultValue: 0);
        }
    }
}
