using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiRH.Migrations
{
    public partial class VotedUpd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateAt",
                table: "Voted",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Fk_Answer",
                table: "Voted",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Voted_Fk_Answer",
                table: "Voted",
                column: "Fk_Answer");

            migrationBuilder.AddForeignKey(
                name: "FK_Voted_Answer_Fk_Answer",
                table: "Voted",
                column: "Fk_Answer",
                principalTable: "Answer",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voted_Answer_Fk_Answer",
                table: "Voted");

            migrationBuilder.DropIndex(
                name: "IX_Voted_Fk_Answer",
                table: "Voted");

            migrationBuilder.DropColumn(
                name: "DateAt",
                table: "Voted");

            migrationBuilder.DropColumn(
                name: "Fk_Answer",
                table: "Voted");
        }
    }
}
