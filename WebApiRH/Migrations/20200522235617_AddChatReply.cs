using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiRH.Migrations
{
    public partial class AddChatReply : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupChat_User_FK_Author",
                table: "GroupChat");

            migrationBuilder.AlterColumn<string>(
                name: "FK_Author",
                table: "GroupChat",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_GroupChat_User_FK_Author",
                table: "GroupChat",
                column: "FK_Author",
                principalTable: "User",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupChat_User_FK_Author",
                table: "GroupChat");

            migrationBuilder.AlterColumn<string>(
                name: "FK_Author",
                table: "GroupChat",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupChat_User_FK_Author",
                table: "GroupChat",
                column: "FK_Author",
                principalTable: "User",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
