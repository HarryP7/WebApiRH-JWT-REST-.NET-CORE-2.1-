using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiRH.Migrations
{
    public partial class addedNullable4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Home_Images_Fk_ImageUrl",
                table: "Home");

            migrationBuilder.DropForeignKey(
                name: "FK_LocalGroup_Images_Fk_Image",
                table: "LocalGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Images_Fk_Image",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Images_Fk_Avatar",
                table: "User");

            migrationBuilder.AlterColumn<Guid>(
                name: "Fk_Avatar",
                table: "User",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "Fk_Image",
                table: "Message",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "Fk_Image",
                table: "LocalGroup",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "Fk_ImageUrl",
                table: "Home",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Home_Images_Fk_ImageUrl",
                table: "Home",
                column: "Fk_ImageUrl",
                principalTable: "Images",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LocalGroup_Images_Fk_Image",
                table: "LocalGroup",
                column: "Fk_Image",
                principalTable: "Images",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Images_Fk_Image",
                table: "Message",
                column: "Fk_Image",
                principalTable: "Images",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Images_Fk_Avatar",
                table: "User",
                column: "Fk_Avatar",
                principalTable: "Images",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Home_Images_Fk_ImageUrl",
                table: "Home");

            migrationBuilder.DropForeignKey(
                name: "FK_LocalGroup_Images_Fk_Image",
                table: "LocalGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Images_Fk_Image",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Images_Fk_Avatar",
                table: "User");

            migrationBuilder.AlterColumn<Guid>(
                name: "Fk_Avatar",
                table: "User",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Fk_Image",
                table: "Message",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Fk_Image",
                table: "LocalGroup",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Fk_ImageUrl",
                table: "Home",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Home_Images_Fk_ImageUrl",
                table: "Home",
                column: "Fk_ImageUrl",
                principalTable: "Images",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocalGroup_Images_Fk_Image",
                table: "LocalGroup",
                column: "Fk_Image",
                principalTable: "Images",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Images_Fk_Image",
                table: "Message",
                column: "Fk_Image",
                principalTable: "Images",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Images_Fk_Avatar",
                table: "User",
                column: "Fk_Avatar",
                principalTable: "Images",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
