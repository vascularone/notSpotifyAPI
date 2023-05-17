using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotSpotifyAPI.Migrations
{
    /// <inheritdoc />
    public partial class bugs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPlaylists_Playlists_PlaylistId",
                table: "UserPlaylists");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPlaylists_Users_UserId",
                table: "UserPlaylists");

            migrationBuilder.CreateIndex(
                name: "IX_UserPlaylists_PlaylistId",
                table: "UserPlaylists",
                column: "PlaylistId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPlaylists_Playlists_PlaylistId",
                table: "UserPlaylists",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPlaylists_Playlists_PlaylistId",
                table: "UserPlaylists");

            migrationBuilder.DropIndex(
                name: "IX_UserPlaylists_PlaylistId",
                table: "UserPlaylists");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPlaylists_Playlists_PlaylistId",
                table: "UserPlaylists",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPlaylists_Users_UserId",
                table: "UserPlaylists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
