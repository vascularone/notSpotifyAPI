using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotSpotifyAPI.Migrations
{
    /// <inheritdoc />
    public partial class modifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPlaylists_Playlists_PlaylistId",
                table: "UserPlaylists");

            migrationBuilder.DropIndex(
                name: "IX_UserPlaylists_PlaylistId",
                table: "UserPlaylists");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "UserPlaylists",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDateTime",
                table: "UserPlaylists",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "InsertedBy",
                table: "UserPlaylists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "UserPlaylists",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "UserPlaylists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Playlists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserPlaylistsId",
                table: "Playlists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPlaylists_UserId",
                table: "UserPlaylists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_UserId",
                table: "Playlists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_UserPlaylistsId",
                table: "Playlists",
                column: "UserPlaylistsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_UserPlaylists_UserPlaylistsId",
                table: "Playlists",
                column: "UserPlaylistsId",
                principalTable: "UserPlaylists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_Users_UserId",
                table: "Playlists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPlaylists_Users_UserId",
                table: "UserPlaylists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_UserPlaylists_UserPlaylistsId",
                table: "Playlists");

            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_Users_UserId",
                table: "Playlists");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPlaylists_Users_UserId",
                table: "UserPlaylists");

            migrationBuilder.DropIndex(
                name: "IX_UserPlaylists_UserId",
                table: "UserPlaylists");

            migrationBuilder.DropIndex(
                name: "IX_Playlists_UserId",
                table: "Playlists");

            migrationBuilder.DropIndex(
                name: "IX_Playlists_UserPlaylistsId",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "UserPlaylists");

            migrationBuilder.DropColumn(
                name: "InsertDateTime",
                table: "UserPlaylists");

            migrationBuilder.DropColumn(
                name: "InsertedBy",
                table: "UserPlaylists");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "UserPlaylists");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "UserPlaylists");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "UserPlaylistsId",
                table: "Playlists");

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
    }
}
