using NotSpotifyAPI.Domain.Models;

namespace Application.Common.Interfaces.Repositories
{
    public interface ISongRepository : IBaseRepository<Song>
    {
        Song GetSong(int id);
        List<Song> GetAllSongs();
    }
}
