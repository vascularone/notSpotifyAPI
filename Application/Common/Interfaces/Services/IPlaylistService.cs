using Application.Common.DTO;
using NotSpotifyAPI.Domain.DTO;
using NotSpotifyAPI.Domain.Models;

namespace NotSpotify.Application.Common.Interfaces.Services
{
    public interface IPlaylistService
    {

        Playlist GetPlaylistById(int id);
        List<Playlist> GetPlaylistByUserId(int userId);
        bool DeletePlaylist(int playlistId);
        List<Song> GetSongsByPlaylistId(int playlistId);
        Playlist CreatePlaylist(PlaylistDTO playlist);
    }
}
