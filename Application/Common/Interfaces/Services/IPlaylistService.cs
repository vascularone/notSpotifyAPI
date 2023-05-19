using Application.Common.DTO;
using NotSpotifyAPI.Domain.Models;

namespace NotSpotify.Application.Common.Interfaces.Services
{
    public interface IPlaylistService
    {

        Playlist GetPlaylistById(int id);
        List<Playlist> GetPlaylistByUserId(int userId);

        List<Song> GetSongsByPlaylistId(int playlistId);
    }
}
