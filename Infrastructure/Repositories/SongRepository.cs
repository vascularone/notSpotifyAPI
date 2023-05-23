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
            return this._dbContext.Songs.Where(p => p.Deleted == false).ToList();
        }

        public Song GetSong(int id)
        {
            return this._dbContext.Songs.FirstOrDefault(x => x.Id == id);
        }

        public CurrentSong GetCurrentSong()
        {
            return this._dbContext.CurrentSong.FirstOrDefault();
        }

        public CurrentSong UpdateCurrentSong(int id, SongDTO song)
        {
            var s = this._dbContext.CurrentSong.FirstOrDefault();
            if (s == null)
            {
                return null;
            }
            s.Artist = song.Artist;
            s.Name = song.Name;
            s.LinkRef = song.LinkRef;
            _dbContext.SaveChanges();
            return s;

        }
    }
}
