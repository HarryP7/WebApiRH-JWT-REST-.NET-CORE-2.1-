using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiRH.Migrations
{
    public partial class addedNullable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupChat_Images_Fk_Image",
                table: "GroupChat");

            migrationBuilder.AlterColumn<Guid>(
                name: "Fk_Image",
                table: "GroupChat",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_GroupChat_Images_Fk_Image",
                table: "GroupChat",
                column: "Fk_Image",
                principalTable: "Images",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupChat_Images_Fk_Image",
                table: "GroupChat");

            migrationBuilder.AlterColumn<Guid>(
                name: "Fk_Image",
                table: "GroupChat",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupChat_Images_Fk_Image",
                table: "GroupChat",
                column: "Fk_Image",
                principalTable: "Images",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
