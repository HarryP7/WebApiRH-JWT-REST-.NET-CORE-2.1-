using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiRH.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Uid = table.Column<string>(nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    Url = table.Column<string>(type: "varchar(200)", nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Removed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Uid);
                });

            migrationBuilder.CreateTable(
                name: "AdvertsReviews",
                columns: table => new
                {
                    Uid = table.Column<string>(nullable: false),
                    Fk_Author = table.Column<string>(nullable: true),
                    Reviews = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    Fk_Advert = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    EditedAt = table.Column<DateTime>(nullable: false),
                    Removed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertsReviews", x => x.Uid);
                });

            migrationBuilder.CreateTable(
                name: "Votings",
                columns: table => new
                {
                    Uid = table.Column<string>(nullable: false),
                    Title = table.Column<string>(type: "varchar(200)", nullable: false),
                    yourOption = table.Column<string>(type: "varchar(50)", nullable: true),
                    isMulti = table.Column<bool>(nullable: false),
                    Fk_Advert = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votings", x => x.Uid);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Uid = table.Column<string>(nullable: false),
                    Option = table.Column<string>(type: "varchar(50)", nullable: true),
                    Count = table.Column<int>(nullable: false),
                    Fk_Voting = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_Answers_Votings_Fk_Voting",
                        column: x => x.Fk_Voting,
                        principalTable: "Votings",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LocalGroups",
                columns: table => new
                {
                    Uid = table.Column<string>(nullable: false),
                    FK_Admin = table.Column<string>(nullable: true),
                    Fk_Image = table.Column<string>(nullable: true),
                    Fk_Status = table.Column<int>(nullable: false),
                    Fk_Home = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    EditedAt = table.Column<DateTime>(nullable: false),
                    Removed = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalGroups", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_LocalGroups_Images_Fk_Image",
                        column: x => x.Fk_Image,
                        principalTable: "Images",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Adverts",
                columns: table => new
                {
                    Uid = table.Column<string>(nullable: false),
                    Title = table.Column<string>(type: "varchar(200)", nullable: false),
                    Text = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    Fk_Image = table.Column<string>(nullable: true),
                    Fk_Category = table.Column<int>(nullable: false),
                    TotalVotes = table.Column<int>(nullable: false),
                    Fk_LocalGroup = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    EditedAt = table.Column<DateTime>(nullable: false),
                    Removed = table.Column<bool>(nullable: false),
                    Category = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adverts", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_Adverts_Images_Fk_Image",
                        column: x => x.Fk_Image,
                        principalTable: "Images",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Adverts_LocalGroups_Fk_LocalGroup",
                        column: x => x.Fk_LocalGroup,
                        principalTable: "LocalGroups",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Uid = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(type: "varchar(100)", nullable: false),
                    GenderId = table.Column<int>(nullable: true),
                    Login = table.Column<string>(type: "varchar(30)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(15)", nullable: true),
                    Fk_Avatar = table.Column<string>(nullable: true),
                    Appartament = table.Column<int>(nullable: false),
                    Fk_Role = table.Column<int>(nullable: false),
                    Fk_Home = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    EditedAt = table.Column<DateTime>(nullable: false),
                    Removed = table.Column<bool>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_Users_Images_Fk_Avatar",
                        column: x => x.Fk_Avatar,
                        principalTable: "Images",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroupChats",
                columns: table => new
                {
                    Uid = table.Column<string>(nullable: false),
                    FK_Author = table.Column<string>(nullable: true),
                    Message = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    Fk_LocalGroup = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    EditedAt = table.Column<DateTime>(nullable: false),
                    Removed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupChats", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_GroupChats_Users_FK_Author",
                        column: x => x.FK_Author,
                        principalTable: "Users",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GroupChats_LocalGroups_Fk_LocalGroup",
                        column: x => x.Fk_LocalGroup,
                        principalTable: "LocalGroups",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Homes",
                columns: table => new
                {
                    Uid = table.Column<string>(nullable: false),
                    FK_Admin = table.Column<string>(nullable: true),
                    Fk_ImageUrl = table.Column<string>(nullable: true),
                    Location = table.Column<string>(type: "varchar(200)", nullable: false),
                    Fk_Status = table.Column<int>(nullable: false),
                    Appartaments = table.Column<int>(nullable: false),
                    Floors = table.Column<int>(nullable: false),
                    Porches = table.Column<int>(nullable: false),
                    YearCommissioning = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    EditedAt = table.Column<DateTime>(nullable: false),
                    Removed = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homes", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_Homes_Users_FK_Admin",
                        column: x => x.FK_Admin,
                        principalTable: "Users",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Homes_Images_Fk_ImageUrl",
                        column: x => x.Fk_ImageUrl,
                        principalTable: "Images",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Uid = table.Column<string>(nullable: false),
                    Fk_User = table.Column<string>(nullable: true),
                    Fk_LocalGroup = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_Participants_LocalGroups_Fk_LocalGroup",
                        column: x => x.Fk_LocalGroup,
                        principalTable: "LocalGroups",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Participants_Users_Fk_User",
                        column: x => x.Fk_User,
                        principalTable: "Users",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_Fk_Image",
                table: "Adverts",
                column: "Fk_Image");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_Fk_LocalGroup",
                table: "Adverts",
                column: "Fk_LocalGroup");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertsReviews_Fk_Advert",
                table: "AdvertsReviews",
                column: "Fk_Advert");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertsReviews_Fk_Author",
                table: "AdvertsReviews",
                column: "Fk_Author");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_Fk_Voting",
                table: "Answers",
                column: "Fk_Voting");

            migrationBuilder.CreateIndex(
                name: "IX_GroupChats_FK_Author",
                table: "GroupChats",
                column: "FK_Author");

            migrationBuilder.CreateIndex(
                name: "IX_GroupChats_Fk_LocalGroup",
                table: "GroupChats",
                column: "Fk_LocalGroup");

            migrationBuilder.CreateIndex(
                name: "IX_Homes_FK_Admin",
                table: "Homes",
                column: "FK_Admin");

            migrationBuilder.CreateIndex(
                name: "IX_Homes_Fk_ImageUrl",
                table: "Homes",
                column: "Fk_ImageUrl");

            migrationBuilder.CreateIndex(
                name: "IX_LocalGroups_FK_Admin",
                table: "LocalGroups",
                column: "FK_Admin");

            migrationBuilder.CreateIndex(
                name: "IX_LocalGroups_Fk_Home",
                table: "LocalGroups",
                column: "Fk_Home");

            migrationBuilder.CreateIndex(
                name: "IX_LocalGroups_Fk_Image",
                table: "LocalGroups",
                column: "Fk_Image");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_Fk_LocalGroup",
                table: "Participants",
                column: "Fk_LocalGroup");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_Fk_User",
                table: "Participants",
                column: "Fk_User");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Fk_Avatar",
                table: "Users",
                column: "Fk_Avatar");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Fk_Home",
                table: "Users",
                column: "Fk_Home");

            migrationBuilder.CreateIndex(
                name: "IX_Votings_Fk_Advert",
                table: "Votings",
                column: "Fk_Advert");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertsReviews_Adverts_Fk_Advert",
                table: "AdvertsReviews",
                column: "Fk_Advert",
                principalTable: "Adverts",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertsReviews_Users_Fk_Author",
                table: "AdvertsReviews",
                column: "Fk_Author",
                principalTable: "Users",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Votings_Adverts_Fk_Advert",
                table: "Votings",
                column: "Fk_Advert",
                principalTable: "Adverts",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LocalGroups_Users_FK_Admin",
                table: "LocalGroups",
                column: "FK_Admin",
                principalTable: "Users",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LocalGroups_Homes_Fk_Home",
                table: "LocalGroups",
                column: "Fk_Home",
                principalTable: "Homes",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Homes_Fk_Home",
                table: "Users",
                column: "Fk_Home",
                principalTable: "Homes",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homes_Images_Fk_ImageUrl",
                table: "Homes");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Images_Fk_Avatar",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Homes_Users_FK_Admin",
                table: "Homes");

            migrationBuilder.DropTable(
                name: "AdvertsReviews");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "GroupChats");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "Votings");

            migrationBuilder.DropTable(
                name: "Adverts");

            migrationBuilder.DropTable(
                name: "LocalGroups");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Homes");
        }
    }
}
