using Application.Common.DTO;
using NotSpotify.Application.Common.Interfaces.Services;
using NotSpotifyAPI.Domain.Models;

namespace NotSpotifyAPI.Application.Services
{
    public class PlaylistService : IPlaylistService
    {
        public Task<ResponseDTO<bool>> CreatePlaylist(Playlist playlist)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<bool>> DeletePlaylist(string id)
        {
            throw new NotImplementedException();
        }

        public Playlist GetPlaylistById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<List<Playlist>>> GetPlaylists()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<bool>> UpdateUser(Playlist playlist)
        {
            throw new NotImplementedException();
        }
    }
}
