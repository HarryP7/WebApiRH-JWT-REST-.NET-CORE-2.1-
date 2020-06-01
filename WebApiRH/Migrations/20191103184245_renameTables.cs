using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiRH.Migrations
{
    public partial class renameTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_Images_Fk_Image",
                table: "Adverts");

            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_LocalGroups_Fk_LocalGroup",
                table: "Adverts");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvertsReviews_Adverts_Fk_Advert",
                table: "AdvertsReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvertsReviews_Users_Fk_Author",
                table: "AdvertsReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Votings_Fk_Voting",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupChats_Users_FK_Author",
                table: "GroupChats");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupChats_LocalGroups_Fk_LocalGroup",
                table: "GroupChats");

            migrationBuilder.DropForeignKey(
                name: "FK_Homes_Users_FK_Admin",
                table: "Homes");

            migrationBuilder.DropForeignKey(
                name: "FK_Homes_Images_Fk_ImageUrl",
                table: "Homes");

            migrationBuilder.DropForeignKey(
                name: "FK_LocalGroups_Users_FK_Admin",
                table: "LocalGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_LocalGroups_Homes_Fk_Home",
                table: "LocalGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_LocalGroups_Images_Fk_Image",
                table: "LocalGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_LocalGroups_Fk_LocalGroup",
                table: "Participants");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Users_Fk_User",
                table: "Participants");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Images_Fk_Avatar",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Homes_Fk_Home",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Votings_Adverts_Fk_Advert",
                table: "Votings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Votings",
                table: "Votings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participants",
                table: "Participants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocalGroups",
                table: "LocalGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Homes",
                table: "Homes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupChats",
                table: "GroupChats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answers",
                table: "Answers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdvertsReviews",
                table: "AdvertsReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adverts",
                table: "Adverts");

            migrationBuilder.RenameTable(
                name: "Votings",
                newName: "Voting");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Participants",
                newName: "Participant");

            migrationBuilder.RenameTable(
                name: "LocalGroups",
                newName: "LocalGroup");

            migrationBuilder.RenameTable(
                name: "Homes",
                newName: "Home");

            migrationBuilder.RenameTable(
                name: "GroupChats",
                newName: "GroupChat");

            migrationBuilder.RenameTable(
                name: "Answers",
                newName: "Answer");

            migrationBuilder.RenameTable(
                name: "AdvertsReviews",
                newName: "AdvertsReview");

            migrationBuilder.RenameTable(
                name: "Adverts",
                newName: "Advert");

            migrationBuilder.RenameIndex(
                name: "IX_Votings_Fk_Advert",
                table: "Voting",
                newName: "IX_Voting_Fk_Advert");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Fk_Home",
                table: "User",
                newName: "IX_User_Fk_Home");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Fk_Avatar",
                table: "User",
                newName: "IX_User_Fk_Avatar");

            migrationBuilder.RenameIndex(
                name: "IX_Participants_Fk_User",
                table: "Participant",
                newName: "IX_Participant_Fk_User");

            migrationBuilder.RenameIndex(
                name: "IX_Participants_Fk_LocalGroup",
                table: "Participant",
                newName: "IX_Participant_Fk_LocalGroup");

            migrationBuilder.RenameColumn(
                name: "FK_Admin",
                table: "LocalGroup",
                newName: "Fk_Admin");

            migrationBuilder.RenameIndex(
                name: "IX_LocalGroups_Fk_Image",
                table: "LocalGroup",
                newName: "IX_LocalGroup_Fk_Image");

            migrationBuilder.RenameIndex(
                name: "IX_LocalGroups_Fk_Home",
                table: "LocalGroup",
                newName: "IX_LocalGroup_Fk_Home");

            migrationBuilder.RenameIndex(
                name: "IX_LocalGroups_FK_Admin",
                table: "LocalGroup",
                newName: "IX_LocalGroup_Fk_Admin");

            migrationBuilder.RenameIndex(
                name: "IX_Homes_Fk_ImageUrl",
                table: "Home",
                newName: "IX_Home_Fk_ImageUrl");

            migrationBuilder.RenameIndex(
                name: "IX_Homes_FK_Admin",
                table: "Home",
                newName: "IX_Home_FK_Admin");

            migrationBuilder.RenameIndex(
                name: "IX_GroupChats_Fk_LocalGroup",
                table: "GroupChat",
                newName: "IX_GroupChat_Fk_LocalGroup");

            migrationBuilder.RenameIndex(
                name: "IX_GroupChats_FK_Author",
                table: "GroupChat",
                newName: "IX_GroupChat_FK_Author");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_Fk_Voting",
                table: "Answer",
                newName: "IX_Answer_Fk_Voting");

            migrationBuilder.RenameIndex(
                name: "IX_AdvertsReviews_Fk_Author",
                table: "AdvertsReview",
                newName: "IX_AdvertsReview_Fk_Author");

            migrationBuilder.RenameIndex(
                name: "IX_AdvertsReviews_Fk_Advert",
                table: "AdvertsReview",
                newName: "IX_AdvertsReview_Fk_Advert");

            migrationBuilder.RenameIndex(
                name: "IX_Adverts_Fk_LocalGroup",
                table: "Advert",
                newName: "IX_Advert_Fk_LocalGroup");

            migrationBuilder.RenameIndex(
                name: "IX_Adverts_Fk_Image",
                table: "Advert",
                newName: "IX_Advert_Fk_Image");

            migrationBuilder.AlterColumn<string>(
                name: "Fk_Admin",
                table: "LocalGroup",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Voting",
                table: "Voting",
                column: "Uid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Uid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participant",
                table: "Participant",
                column: "Uid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocalGroup",
                table: "LocalGroup",
                column: "Uid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Home",
                table: "Home",
                column: "Uid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupChat",
                table: "GroupChat",
                column: "Uid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answer",
                table: "Answer",
                column: "Uid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdvertsReview",
                table: "AdvertsReview",
                column: "Uid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Advert",
                table: "Advert",
                column: "Uid");

            migrationBuilder.AddForeignKey(
                name: "FK_Advert_Images_Fk_Image",
                table: "Advert",
                column: "Fk_Image",
                principalTable: "Images",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Advert_LocalGroup_Fk_LocalGroup",
                table: "Advert",
                column: "Fk_LocalGroup",
                principalTable: "LocalGroup",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertsReview_Advert_Fk_Advert",
                table: "AdvertsReview",
                column: "Fk_Advert",
                principalTable: "Advert",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertsReview_User_Fk_Author",
                table: "AdvertsReview",
                column: "Fk_Author",
                principalTable: "User",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Voting_Fk_Voting",
                table: "Answer",
                column: "Fk_Voting",
                principalTable: "Voting",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupChat_User_FK_Author",
                table: "GroupChat",
                column: "FK_Author",
                principalTable: "User",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupChat_LocalGroup_Fk_LocalGroup",
                table: "GroupChat",
                column: "Fk_LocalGroup",
                principalTable: "LocalGroup",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Home_User_FK_Admin",
                table: "Home",
                column: "FK_Admin",
                principalTable: "User",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Home_Images_Fk_ImageUrl",
                table: "Home",
                column: "Fk_ImageUrl",
                principalTable: "Images",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LocalGroup_User_Fk_Admin",
                table: "LocalGroup",
                column: "Fk_Admin",
                principalTable: "User",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocalGroup_Home_Fk_Home",
                table: "LocalGroup",
                column: "Fk_Home",
                principalTable: "Home",
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
                name: "FK_Participant_LocalGroup_Fk_LocalGroup",
                table: "Participant",
                column: "Fk_LocalGroup",
                principalTable: "LocalGroup",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Participant_User_Fk_User",
                table: "Participant",
                column: "Fk_User",
                principalTable: "User",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Images_Fk_Avatar",
                table: "User",
                column: "Fk_Avatar",
                principalTable: "Images",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Home_Fk_Home",
                table: "User",
                column: "Fk_Home",
                principalTable: "Home",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Voting_Advert_Fk_Advert",
                table: "Voting",
                column: "Fk_Advert",
                principalTable: "Advert",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advert_Images_Fk_Image",
                table: "Advert");

            migrationBuilder.DropForeignKey(
                name: "FK_Advert_LocalGroup_Fk_LocalGroup",
                table: "Advert");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvertsReview_Advert_Fk_Advert",
                table: "AdvertsReview");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvertsReview_User_Fk_Author",
                table: "AdvertsReview");

            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Voting_Fk_Voting",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupChat_User_FK_Author",
                table: "GroupChat");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupChat_LocalGroup_Fk_LocalGroup",
                table: "GroupChat");

            migrationBuilder.DropForeignKey(
                name: "FK_Home_User_FK_Admin",
                table: "Home");

            migrationBuilder.DropForeignKey(
                name: "FK_Home_Images_Fk_ImageUrl",
                table: "Home");

            migrationBuilder.DropForeignKey(
                name: "FK_LocalGroup_User_Fk_Admin",
                table: "LocalGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_LocalGroup_Home_Fk_Home",
                table: "LocalGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_LocalGroup_Images_Fk_Image",
                table: "LocalGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Participant_LocalGroup_Fk_LocalGroup",
                table: "Participant");

            migrationBuilder.DropForeignKey(
                name: "FK_Participant_User_Fk_User",
                table: "Participant");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Images_Fk_Avatar",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Home_Fk_Home",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_Voting_Advert_Fk_Advert",
                table: "Voting");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Voting",
                table: "Voting");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participant",
                table: "Participant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocalGroup",
                table: "LocalGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Home",
                table: "Home");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupChat",
                table: "GroupChat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answer",
                table: "Answer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdvertsReview",
                table: "AdvertsReview");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Advert",
                table: "Advert");

            migrationBuilder.RenameTable(
                name: "Voting",
                newName: "Votings");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Participant",
                newName: "Participants");

            migrationBuilder.RenameTable(
                name: "LocalGroup",
                newName: "LocalGroups");

            migrationBuilder.RenameTable(
                name: "Home",
                newName: "Homes");

            migrationBuilder.RenameTable(
                name: "GroupChat",
                newName: "GroupChats");

            migrationBuilder.RenameTable(
                name: "Answer",
                newName: "Answers");

            migrationBuilder.RenameTable(
                name: "AdvertsReview",
                newName: "AdvertsReviews");

            migrationBuilder.RenameTable(
                name: "Advert",
                newName: "Adverts");

            migrationBuilder.RenameIndex(
                name: "IX_Voting_Fk_Advert",
                table: "Votings",
                newName: "IX_Votings_Fk_Advert");

            migrationBuilder.RenameIndex(
                name: "IX_User_Fk_Home",
                table: "Users",
                newName: "IX_Users_Fk_Home");

            migrationBuilder.RenameIndex(
                name: "IX_User_Fk_Avatar",
                table: "Users",
                newName: "IX_Users_Fk_Avatar");

            migrationBuilder.RenameIndex(
                name: "IX_Participant_Fk_User",
                table: "Participants",
                newName: "IX_Participants_Fk_User");

            migrationBuilder.RenameIndex(
                name: "IX_Participant_Fk_LocalGroup",
                table: "Participants",
                newName: "IX_Participants_Fk_LocalGroup");

            migrationBuilder.RenameColumn(
                name: "Fk_Admin",
                table: "LocalGroups",
                newName: "FK_Admin");

            migrationBuilder.RenameIndex(
                name: "IX_LocalGroup_Fk_Image",
                table: "LocalGroups",
                newName: "IX_LocalGroups_Fk_Image");

            migrationBuilder.RenameIndex(
                name: "IX_LocalGroup_Fk_Home",
                table: "LocalGroups",
                newName: "IX_LocalGroups_Fk_Home");

            migrationBuilder.RenameIndex(
                name: "IX_LocalGroup_Fk_Admin",
                table: "LocalGroups",
                newName: "IX_LocalGroups_FK_Admin");

            migrationBuilder.RenameIndex(
                name: "IX_Home_Fk_ImageUrl",
                table: "Homes",
                newName: "IX_Homes_Fk_ImageUrl");

            migrationBuilder.RenameIndex(
                name: "IX_Home_FK_Admin",
                table: "Homes",
                newName: "IX_Homes_FK_Admin");

            migrationBuilder.RenameIndex(
                name: "IX_GroupChat_Fk_LocalGroup",
                table: "GroupChats",
                newName: "IX_GroupChats_Fk_LocalGroup");

            migrationBuilder.RenameIndex(
                name: "IX_GroupChat_FK_Author",
                table: "GroupChats",
                newName: "IX_GroupChats_FK_Author");

            migrationBuilder.RenameIndex(
                name: "IX_Answer_Fk_Voting",
                table: "Answers",
                newName: "IX_Answers_Fk_Voting");

            migrationBuilder.RenameIndex(
                name: "IX_AdvertsReview_Fk_Author",
                table: "AdvertsReviews",
                newName: "IX_AdvertsReviews_Fk_Author");

            migrationBuilder.RenameIndex(
                name: "IX_AdvertsReview_Fk_Advert",
                table: "AdvertsReviews",
                newName: "IX_AdvertsReviews_Fk_Advert");

            migrationBuilder.RenameIndex(
                name: "IX_Advert_Fk_LocalGroup",
                table: "Adverts",
                newName: "IX_Adverts_Fk_LocalGroup");

            migrationBuilder.RenameIndex(
                name: "IX_Advert_Fk_Image",
                table: "Adverts",
                newName: "IX_Adverts_Fk_Image");

            migrationBuilder.AlterColumn<string>(
                name: "FK_Admin",
                table: "LocalGroups",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Votings",
                table: "Votings",
                column: "Uid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Uid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participants",
                table: "Participants",
                column: "Uid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocalGroups",
                table: "LocalGroups",
                column: "Uid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Homes",
                table: "Homes",
                column: "Uid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupChats",
                table: "GroupChats",
                column: "Uid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answers",
                table: "Answers",
                column: "Uid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdvertsReviews",
                table: "AdvertsReviews",
                column: "Uid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adverts",
                table: "Adverts",
                column: "Uid");

            migrationBuilder.AddForeignKey(
                name: "FK_Adverts_Images_Fk_Image",
                table: "Adverts",
                column: "Fk_Image",
                principalTable: "Images",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Adverts_LocalGroups_Fk_LocalGroup",
                table: "Adverts",
                column: "Fk_LocalGroup",
                principalTable: "LocalGroups",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Answers_Votings_Fk_Voting",
                table: "Answers",
                column: "Fk_Voting",
                principalTable: "Votings",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupChats_Users_FK_Author",
                table: "GroupChats",
                column: "FK_Author",
                principalTable: "Users",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupChats_LocalGroups_Fk_LocalGroup",
                table: "GroupChats",
                column: "Fk_LocalGroup",
                principalTable: "LocalGroups",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Homes_Users_FK_Admin",
                table: "Homes",
                column: "FK_Admin",
                principalTable: "Users",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Homes_Images_Fk_ImageUrl",
                table: "Homes",
                column: "Fk_ImageUrl",
                principalTable: "Images",
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
                name: "FK_LocalGroups_Images_Fk_Image",
                table: "LocalGroups",
                column: "Fk_Image",
                principalTable: "Images",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_LocalGroups_Fk_LocalGroup",
                table: "Participants",
                column: "Fk_LocalGroup",
                principalTable: "LocalGroups",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Users_Fk_User",
                table: "Participants",
                column: "Fk_User",
                principalTable: "Users",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Images_Fk_Avatar",
                table: "Users",
                column: "Fk_Avatar",
                principalTable: "Images",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Homes_Fk_Home",
                table: "Users",
                column: "Fk_Home",
                principalTable: "Homes",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Votings_Adverts_Fk_Advert",
                table: "Votings",
                column: "Fk_Advert",
                principalTable: "Adverts",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
