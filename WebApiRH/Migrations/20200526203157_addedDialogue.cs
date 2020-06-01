using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiRH.Migrations
{
    public partial class addedDialogue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Uid = table.Column<Guid>(nullable: false),
                    Url = table.Column<string>(type: "varchar(200)", nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UrlRemove = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Uid);
                });

            migrationBuilder.CreateTable(
                name: "AdvertsReview",
                columns: table => new
                {
                    Uid = table.Column<Guid>(nullable: false),
                    Fk_Author = table.Column<Guid>(nullable: false),
                    Reviews = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Fk_Advert = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    EditedAt = table.Column<DateTime>(nullable: false),
                    Removed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertsReview", x => x.Uid);
                });

            migrationBuilder.CreateTable(
                name: "Voting",
                columns: table => new
                {
                    Uid = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    YourOption = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    IsMulti = table.Column<bool>(nullable: false),
                    Fk_Advert = table.Column<Guid>(nullable: false),
                    TotalVotes = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    EditedAt = table.Column<DateTime>(nullable: false),
                    Removed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voting", x => x.Uid);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    Uid = table.Column<Guid>(nullable: false),
                    Option = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Count = table.Column<int>(nullable: false),
                    Fk_Voting = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_Answer_Voting_Fk_Voting",
                        column: x => x.Fk_Voting,
                        principalTable: "Voting",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Voted",
                columns: table => new
                {
                    Uid = table.Column<Guid>(nullable: false),
                    Fk_User = table.Column<Guid>(nullable: false),
                    Fk_Voting = table.Column<Guid>(nullable: false),
                    Fk_Answer = table.Column<Guid>(nullable: false),
                    DateAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voted", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_Voted_Answer_Fk_Answer",
                        column: x => x.Fk_Answer,
                        principalTable: "Answer",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Voted_Voting_Fk_Voting",
                        column: x => x.Fk_Voting,
                        principalTable: "Voting",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Uid = table.Column<Guid>(nullable: false),
                    Fk_Author = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Fk_Dialogue = table.Column<Guid>(nullable: false),
                    Fk_Image = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    EditedAt = table.Column<DateTime>(nullable: false),
                    Removed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_Message_Images_Fk_Image",
                        column: x => x.Fk_Image,
                        principalTable: "Images",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ChatReply",
                columns: table => new
                {
                    Uid = table.Column<Guid>(nullable: false),
                    FK_Author = table.Column<Guid>(nullable: false),
                    Reply = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Fk_GroupChat = table.Column<Guid>(nullable: false),
                    Fk_Image = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    EditedAt = table.Column<DateTime>(nullable: false),
                    Removed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatReply", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_ChatReply_Images_Fk_Image",
                        column: x => x.Fk_Image,
                        principalTable: "Images",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LocalGroup",
                columns: table => new
                {
                    Uid = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Fk_Supervisor = table.Column<Guid>(nullable: false),
                    Fk_Image = table.Column<Guid>(nullable: false),
                    Fk_Status = table.Column<int>(nullable: false),
                    Fk_Home = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    EditedAt = table.Column<DateTime>(nullable: false),
                    Removed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalGroup", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_LocalGroup_Images_Fk_Image",
                        column: x => x.Fk_Image,
                        principalTable: "Images",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Uid = table.Column<Guid>(nullable: false),
                    FullName = table.Column<string>(type: "Nvarchar(100)", nullable: false),
                    Fk_Gender = table.Column<int>(nullable: true),
                    Login = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: true),
                    Phone = table.Column<string>(type: "varchar(17)", nullable: true),
                    Fk_Avatar = table.Column<Guid>(nullable: false),
                    Appartament = table.Column<int>(nullable: false),
                    Fk_Role = table.Column<int>(nullable: false),
                    Fk_Home = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(type: "Nvarchar(MAX)", nullable: true),
                    IsApprovedHome = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    EditedAt = table.Column<DateTime>(nullable: false),
                    Removed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_User_Images_Fk_Avatar",
                        column: x => x.Fk_Avatar,
                        principalTable: "Images",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Advert",
                columns: table => new
                {
                    Uid = table.Column<Guid>(nullable: false),
                    Fk_Author = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Fk_Image = table.Column<Guid>(nullable: false),
                    Fk_Category = table.Column<int>(nullable: false),
                    Fk_LocalGroup = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    EditedAt = table.Column<DateTime>(nullable: false),
                    Removed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advert", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_Advert_User_Fk_Author",
                        column: x => x.Fk_Author,
                        principalTable: "User",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Advert_Images_Fk_Image",
                        column: x => x.Fk_Image,
                        principalTable: "Images",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Advert_LocalGroup_Fk_LocalGroup",
                        column: x => x.Fk_LocalGroup,
                        principalTable: "LocalGroup",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Dialogue",
                columns: table => new
                {
                    Uid = table.Column<Guid>(nullable: false),
                    FkUser1 = table.Column<Guid>(nullable: false),
                    FkUser2 = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    EditedAt = table.Column<DateTime>(nullable: false),
                    Removed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dialogue", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_Dialogue_User_FkUser1",
                        column: x => x.FkUser1,
                        principalTable: "User",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Dialogue_User_FkUser2",
                        column: x => x.FkUser2,
                        principalTable: "User",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "GroupChat",
                columns: table => new
                {
                    Uid = table.Column<Guid>(nullable: false),
                    Fk_Author = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Fk_LocalGroup = table.Column<Guid>(nullable: false),
                    Fk_Image = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    EditedAt = table.Column<DateTime>(nullable: false),
                    Removed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupChat", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_GroupChat_User_Fk_Author",
                        column: x => x.Fk_Author,
                        principalTable: "User",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GroupChat_Images_Fk_Image",
                        column: x => x.Fk_Image,
                        principalTable: "Images",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GroupChat_LocalGroup_Fk_LocalGroup",
                        column: x => x.Fk_LocalGroup,
                        principalTable: "LocalGroup",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Home",
                columns: table => new
                {
                    Uid = table.Column<Guid>(nullable: false),
                    Fk_Manager = table.Column<Guid>(nullable: false),
                    Fk_ImageUrl = table.Column<Guid>(nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    HomeNumber = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    Fk_Status = table.Column<int>(nullable: false),
                    Appartaments = table.Column<int>(nullable: false),
                    Floors = table.Column<int>(nullable: false),
                    Porches = table.Column<int>(nullable: false),
                    YearCommissioning = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    EditedAt = table.Column<DateTime>(nullable: false),
                    Removed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Home", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_Home_Images_Fk_ImageUrl",
                        column: x => x.Fk_ImageUrl,
                        principalTable: "Images",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Home_User_Fk_Manager",
                        column: x => x.Fk_Manager,
                        principalTable: "User",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    Uid = table.Column<Guid>(nullable: false),
                    Fk_User = table.Column<Guid>(nullable: false),
                    Fk_LocalGroup = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_Participant_LocalGroup_Fk_LocalGroup",
                        column: x => x.Fk_LocalGroup,
                        principalTable: "LocalGroup",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Participant_User_Fk_User",
                        column: x => x.Fk_User,
                        principalTable: "User",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advert_Fk_Author",
                table: "Advert",
                column: "Fk_Author");

            migrationBuilder.CreateIndex(
                name: "IX_Advert_Fk_Image",
                table: "Advert",
                column: "Fk_Image");

            migrationBuilder.CreateIndex(
                name: "IX_Advert_Fk_LocalGroup",
                table: "Advert",
                column: "Fk_LocalGroup");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertsReview_Fk_Advert",
                table: "AdvertsReview",
                column: "Fk_Advert");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertsReview_Fk_Author",
                table: "AdvertsReview",
                column: "Fk_Author");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_Fk_Voting",
                table: "Answer",
                column: "Fk_Voting");

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

            migrationBuilder.CreateIndex(
                name: "IX_Dialogue_FkUser1",
                table: "Dialogue",
                column: "FkUser1");

            migrationBuilder.CreateIndex(
                name: "IX_Dialogue_FkUser2",
                table: "Dialogue",
                column: "FkUser2");

            migrationBuilder.CreateIndex(
                name: "IX_GroupChat_Fk_Author",
                table: "GroupChat",
                column: "Fk_Author");

            migrationBuilder.CreateIndex(
                name: "IX_GroupChat_Fk_Image",
                table: "GroupChat",
                column: "Fk_Image");

            migrationBuilder.CreateIndex(
                name: "IX_GroupChat_Fk_LocalGroup",
                table: "GroupChat",
                column: "Fk_LocalGroup");

            migrationBuilder.CreateIndex(
                name: "IX_Home_Fk_ImageUrl",
                table: "Home",
                column: "Fk_ImageUrl");

            migrationBuilder.CreateIndex(
                name: "IX_Home_Fk_Manager",
                table: "Home",
                column: "Fk_Manager");

            migrationBuilder.CreateIndex(
                name: "IX_LocalGroup_Fk_Home",
                table: "LocalGroup",
                column: "Fk_Home");

            migrationBuilder.CreateIndex(
                name: "IX_LocalGroup_Fk_Image",
                table: "LocalGroup",
                column: "Fk_Image");

            migrationBuilder.CreateIndex(
                name: "IX_LocalGroup_Fk_Supervisor",
                table: "LocalGroup",
                column: "Fk_Supervisor");

            migrationBuilder.CreateIndex(
                name: "IX_Message_Fk_Author",
                table: "Message",
                column: "Fk_Author");

            migrationBuilder.CreateIndex(
                name: "IX_Message_Fk_Dialogue",
                table: "Message",
                column: "Fk_Dialogue");

            migrationBuilder.CreateIndex(
                name: "IX_Message_Fk_Image",
                table: "Message",
                column: "Fk_Image");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_Fk_LocalGroup",
                table: "Participant",
                column: "Fk_LocalGroup");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_Fk_User",
                table: "Participant",
                column: "Fk_User");

            migrationBuilder.CreateIndex(
                name: "IX_User_Fk_Avatar",
                table: "User",
                column: "Fk_Avatar");

            migrationBuilder.CreateIndex(
                name: "IX_User_Fk_Home",
                table: "User",
                column: "Fk_Home");

            migrationBuilder.CreateIndex(
                name: "IX_Voted_Fk_Answer",
                table: "Voted",
                column: "Fk_Answer");

            migrationBuilder.CreateIndex(
                name: "IX_Voted_Fk_User",
                table: "Voted",
                column: "Fk_User");

            migrationBuilder.CreateIndex(
                name: "IX_Voted_Fk_Voting",
                table: "Voted",
                column: "Fk_Voting");

            migrationBuilder.CreateIndex(
                name: "IX_Voting_Fk_Advert",
                table: "Voting",
                column: "Fk_Advert");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertsReview_User_Fk_Author",
                table: "AdvertsReview",
                column: "Fk_Author",
                principalTable: "User",
                principalColumn: "Uid",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertsReview_Advert_Fk_Advert",
                table: "AdvertsReview",
                column: "Fk_Advert",
                principalTable: "Advert",
                principalColumn: "Uid",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Voting_Advert_Fk_Advert",
                table: "Voting",
                column: "Fk_Advert",
                principalTable: "Advert",
                principalColumn: "Uid",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Voted_User_Fk_User",
                table: "Voted",
                column: "Fk_User",
                principalTable: "User",
                principalColumn: "Uid",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_Fk_Author",
                table: "Message",
                column: "Fk_Author",
                principalTable: "User",
                principalColumn: "Uid",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Dialogue_Fk_Dialogue",
                table: "Message",
                column: "Fk_Dialogue",
                principalTable: "Dialogue",
                principalColumn: "Uid",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatReply_User_FK_Author",
                table: "ChatReply",
                column: "FK_Author",
                principalTable: "User",
                principalColumn: "Uid",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatReply_GroupChat_Fk_GroupChat",
                table: "ChatReply",
                column: "Fk_GroupChat",
                principalTable: "GroupChat",
                principalColumn: "Uid",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_LocalGroup_User_Fk_Supervisor",
                table: "LocalGroup",
                column: "Fk_Supervisor",
                principalTable: "User",
                principalColumn: "Uid",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_LocalGroup_Home_Fk_Home",
                table: "LocalGroup",
                column: "Fk_Home",
                principalTable: "Home",
                principalColumn: "Uid",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Home_Fk_Home",
                table: "User",
                column: "Fk_Home",
                principalTable: "Home",
                principalColumn: "Uid",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Home_User_Fk_Manager",
                table: "Home");

            migrationBuilder.DropTable(
                name: "AdvertsReview");

            migrationBuilder.DropTable(
                name: "ChatReply");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Participant");

            migrationBuilder.DropTable(
                name: "Voted");

            migrationBuilder.DropTable(
                name: "GroupChat");

            migrationBuilder.DropTable(
                name: "Dialogue");

            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "Voting");

            migrationBuilder.DropTable(
                name: "Advert");

            migrationBuilder.DropTable(
                name: "LocalGroup");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Home");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
