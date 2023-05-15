using Application.Common.DTO;
using NotSpotifyAPI.Domain.Models;

namespace NotSpotify.Application.Common.Interfaces.Services
{
    public interface IPlaylistService
    {
        Task<ResponseDTO<bool>> DeletePlaylist(string id);
        Playlist GetPlaylistById(string id);
        Task<ResponseDTO<List<Playlist>>> GetPlaylists();
        Task<ResponseDTO<bool>> UpdateUser(Playlist playlist);
        Task<ResponseDTO<bool>> CreatePlaylist(Playlist playlist);
    }
}
