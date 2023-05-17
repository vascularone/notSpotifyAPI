using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotSpotifyAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserPlaylistsForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPlaylists_Playlists_PlaylistId",
                table: "UserPlaylists");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPlaylists_Users_UserId",
                table: "UserPlaylists");
        }
    }
}
