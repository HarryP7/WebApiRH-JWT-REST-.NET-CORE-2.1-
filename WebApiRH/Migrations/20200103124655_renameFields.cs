using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiRH.Migrations
{
    public partial class renameFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Home_User_FK_Admin",
                table: "Home");

            migrationBuilder.DropForeignKey(
                name: "FK_LocalGroup_User_Fk_Admin",
                table: "LocalGroup");

            migrationBuilder.RenameColumn(
                name: "Fk_Admin",
                table: "LocalGroup",
                newName: "Fk_Supervisor");

            migrationBuilder.RenameIndex(
                name: "IX_LocalGroup_Fk_Admin",
                table: "LocalGroup",
                newName: "IX_LocalGroup_Fk_Supervisor");

            migrationBuilder.RenameColumn(
                name: "FK_Admin",
                table: "Home",
                newName: "Fk_Manager");

            migrationBuilder.RenameIndex(
                name: "IX_Home_FK_Admin",
                table: "Home",
                newName: "IX_Home_Fk_Manager");

            migrationBuilder.AddForeignKey(
                name: "FK_Home_User_Fk_Manager",
                table: "Home",
                column: "Fk_Manager",
                principalTable: "User",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LocalGroup_User_Fk_Supervisor",
                table: "LocalGroup",
                column: "Fk_Supervisor",
                principalTable: "User",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Home_User_Fk_Manager",
                table: "Home");

            migrationBuilder.DropForeignKey(
                name: "FK_LocalGroup_User_Fk_Supervisor",
                table: "LocalGroup");

            migrationBuilder.RenameColumn(
                name: "Fk_Supervisor",
                table: "LocalGroup",
                newName: "Fk_Admin");

            migrationBuilder.RenameIndex(
                name: "IX_LocalGroup_Fk_Supervisor",
                table: "LocalGroup",
                newName: "IX_LocalGroup_Fk_Admin");

            migrationBuilder.RenameColumn(
                name: "Fk_Manager",
                table: "Home",
                newName: "FK_Admin");

            migrationBuilder.RenameIndex(
                name: "IX_Home_Fk_Manager",
                table: "Home",
                newName: "IX_Home_FK_Admin");

            migrationBuilder.AddForeignKey(
                name: "FK_Home_User_FK_Admin",
                table: "Home",
                column: "FK_Admin",
                principalTable: "User",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LocalGroup_User_Fk_Admin",
                table: "LocalGroup",
                column: "Fk_Admin",
                principalTable: "User",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
