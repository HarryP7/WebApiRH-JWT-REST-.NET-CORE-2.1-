using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiRH.Migrations
{
    public partial class addVotedModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Voted",
                columns: table => new
                {
                    Uid = table.Column<string>(nullable: false),
                    Fk_User = table.Column<string>(nullable: false),
                    Fk_Voting = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voted", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_Voted_User_Fk_User",
                        column: x => x.Fk_User,
                        principalTable: "User",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Voted_Voting_Fk_Voting",
                        column: x => x.Fk_Voting,
                        principalTable: "Voting",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Voted_Fk_User",
                table: "Voted",
                column: "Fk_User");

            migrationBuilder.CreateIndex(
                name: "IX_Voted_Fk_Voting",
                table: "Voted",
                column: "Fk_Voting");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Voted");
        }
    }
}
