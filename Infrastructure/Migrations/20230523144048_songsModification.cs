using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotSpotifyAPI.Migrations
{
    /// <inheritdoc />
    public partial class songsModification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlaylistSongsId",
                table: "Songs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_PlaylistSongsId",
                table: "Songs",
                column: "PlaylistSongsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_PlaylistSongs_PlaylistSongsId",
                table: "Songs",
                column: "PlaylistSongsId",
                principalTable: "PlaylistSongs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_PlaylistSongs_PlaylistSongsId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_PlaylistSongsId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "PlaylistSongsId",
                table: "Songs");
        }
    }
}
