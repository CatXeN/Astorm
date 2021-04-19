using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstormAPI.Migrations
{
    public partial class AddPendingRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UsersMessages_OwnerId",
                table: "UsersMessages");

            migrationBuilder.DropIndex(
                name: "IX_UsersMessages_RecipientId",
                table: "UsersMessages");

            migrationBuilder.DropIndex(
                name: "IX_ChannelsMessages_ChannelId",
                table: "ChannelsMessages");

            migrationBuilder.DropIndex(
                name: "IX_ChannelsMessages_OwnerId",
                table: "ChannelsMessages");

            migrationBuilder.AddColumn<Guid>(
                name: "ChannelId1",
                table: "ChannelsMessages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PendingRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FriendId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PendingRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PendingRequests_Users_FriendId",
                        column: x => x.FriendId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PendingRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersMessages_OwnerId",
                table: "UsersMessages",
                column: "OwnerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersMessages_RecipientId",
                table: "UsersMessages",
                column: "RecipientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChannelsMessages_ChannelId",
                table: "ChannelsMessages",
                column: "ChannelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChannelsMessages_ChannelId1",
                table: "ChannelsMessages",
                column: "ChannelId1");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelsMessages_OwnerId",
                table: "ChannelsMessages",
                column: "OwnerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PendingRequests_FriendId",
                table: "PendingRequests",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "IX_PendingRequests_UserId",
                table: "PendingRequests",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChannelsMessages_Channels_ChannelId1",
                table: "ChannelsMessages",
                column: "ChannelId1",
                principalTable: "Channels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChannelsMessages_Channels_ChannelId1",
                table: "ChannelsMessages");

            migrationBuilder.DropTable(
                name: "PendingRequests");

            migrationBuilder.DropIndex(
                name: "IX_UsersMessages_OwnerId",
                table: "UsersMessages");

            migrationBuilder.DropIndex(
                name: "IX_UsersMessages_RecipientId",
                table: "UsersMessages");

            migrationBuilder.DropIndex(
                name: "IX_ChannelsMessages_ChannelId",
                table: "ChannelsMessages");

            migrationBuilder.DropIndex(
                name: "IX_ChannelsMessages_ChannelId1",
                table: "ChannelsMessages");

            migrationBuilder.DropIndex(
                name: "IX_ChannelsMessages_OwnerId",
                table: "ChannelsMessages");

            migrationBuilder.DropColumn(
                name: "ChannelId1",
                table: "ChannelsMessages");

            migrationBuilder.CreateIndex(
                name: "IX_UsersMessages_OwnerId",
                table: "UsersMessages",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersMessages_RecipientId",
                table: "UsersMessages",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelsMessages_ChannelId",
                table: "ChannelsMessages",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelsMessages_OwnerId",
                table: "ChannelsMessages",
                column: "OwnerId");
        }
    }
}
