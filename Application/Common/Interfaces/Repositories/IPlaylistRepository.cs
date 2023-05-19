using NotSpotifyAPI.Domain.Models;

namespace Application.Common.Interfaces.Repositories
{
    public interface IPlaylistRepository : IBaseRepository<Playlist>
    {
        Playlist GetPlaylistById(int id);
        List<Playlist> GetPlaylistsByUserId(int userId);
        List<Song> GetSongsByPlaylistId(int playlistId);
    }
}
