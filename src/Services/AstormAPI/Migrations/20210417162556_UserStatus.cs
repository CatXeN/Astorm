using Microsoft.EntityFrameworkCore.Migrations;

namespace AstormAPI.Migrations
{
    public partial class UserStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FriendsOfUsers_FriendId",
                table: "FriendsOfUsers");

            migrationBuilder.AddColumn<int>(
                name: "UserStatus",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FriendsOfUsers_FriendId",
                table: "FriendsOfUsers",
                column: "FriendId",
                unique: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FriendsOfUsers_FriendId",
                table: "FriendsOfUsers");

            migrationBuilder.DropColumn(
                name: "UserStatus",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_FriendsOfUsers_FriendId",
                table: "FriendsOfUsers",
                column: "FriendId");
        }
    }
}
