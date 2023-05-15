using Application.Common.Interfaces.Repositories;
using Infrastucture.Repositories;
using NotSpotifyAPI.Domain.Models;
using NotSpotifyAPI.Infrastructure.Persistence;

namespace NotSpotifyAPI.Infrastructure.Repositories
{
    public class SongRepository : BaseRepository<Song>, ISongRepository
    {
        public SongRepository(ApplicationDbContext context) : base(context) { }
        public List<Song> GetAllSongs()
        {
           return this._dbContext.Songs.ToList();
        }

        public Song GetSong(int id)
        {
            return this._dbContext.Songs.FirstOrDefault(x => x.Id == id);
        }
    }
}
