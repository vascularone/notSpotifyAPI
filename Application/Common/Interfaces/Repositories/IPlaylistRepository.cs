using NotSpotifyAPI.Domain.Models;

namespace Application.Common.Interfaces.Repositories
{
    public interface IPlaylistRepository : IBaseRepository<Playlist>
    {
        Playlist GetPlaylist(string id);
        List<Playlist> GetAllPlaylists();
    }
}
