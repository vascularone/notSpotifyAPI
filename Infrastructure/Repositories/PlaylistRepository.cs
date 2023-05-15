using Application.Common.Interfaces.Repositories;
using Infrastucture.Repositories;
using NotSpotifyAPI.Domain.Models;
using NotSpotifyAPI.Infrastructure.Persistence;

namespace NotSpotifyAPI.Infrastructure.Repositories
{
    public class PlaylistRepository : BaseRepository<Playlist>, IPlaylistRepository
    {
        public PlaylistRepository(ApplicationDbContext context) : base(context) { }
        public List<Playlist> GetAllPlaylists()
        {
            throw new NotImplementedException();
        }

        public Playlist GetPlaylist(string id)
        {
            throw new NotImplementedException();
        }
    }
}
