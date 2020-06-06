using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiRH.Migrations
{
    public partial class AddChatReplyMore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fk_Image",
                table: "GroupChat",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ChatReply",
                columns: table => new
                {
                    Uid = table.Column<string>(nullable: false),
                    FK_Author = table.Column<string>(nullable: false),
                    Reply = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Fk_GroupChat = table.Column<string>(nullable: false),
                    Fk_Image = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    EditedAt = table.Column<DateTime>(nullable: false),
                    Removed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatReply", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_ChatReply_User_FK_Author",
                        column: x => x.FK_Author,
                        principalTable: "User",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatReply_GroupChat_Fk_GroupChat",
                        column: x => x.Fk_GroupChat,
                        principalTable: "GroupChat",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatReply_Images_Fk_Image",
                        column: x => x.Fk_Image,
                        principalTable: "Images",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupChat_Fk_Image",
                table: "GroupChat",
                column: "Fk_Image");

            migrationBuilder.CreateIndex(
                name: "IX_ChatReply_FK_Author",
                table: "ChatReply",
                column: "FK_Author");

            migrationBuilder.CreateIndex(
                name: "IX_ChatReply_Fk_GroupChat",
                table: "ChatReply",
                column: "Fk_GroupChat");

            migrationBuilder.CreateIndex(
                name: "IX_ChatReply_Fk_Image",
                table: "ChatReply",
                column: "Fk_Image");

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

            migrationBuilder.DropTable(
                name: "ChatReply");

            migrationBuilder.DropIndex(
                name: "IX_GroupChat_Fk_Image",
                table: "GroupChat");

            migrationBuilder.DropColumn(
                name: "Fk_Image",
                table: "GroupChat");
        }
    }
}
