
using Application.Common.Interfaces.Repositories;
using NotSpotify.Application.Common.Interfaces.Services;
using NotSpotifyAPI.Domain.Models;
using Microsoft.Extensions.Caching.Memory;

namespace NotSpotifyAPI.Application.Services
{
    public class SongService : ISongService
    {
        private readonly ISongRepository _songRepository;
        private readonly IMemoryCache _memoryCache;
        private const string CurrentMusicCacheKey = "CurrentMusic";

        public SongService(ISongRepository songRepository, IMemoryCache memoryCache)
        {
            _songRepository = songRepository;
            _memoryCache = memoryCache;
        }
        public List<SongDTO> GetAllSongs()
        {
            var songs = _songRepository.GetAllSongs().Select(x => new SongDTO { Id = x.Id, Name = x.Name, Artist = x.Artist, LinkRef = x.LinkRef });

            return songs.ToList();
        }

        public Song GetSongById(int id)
        {
            var song = _songRepository.GetSong(id);
            return song;
        }

        public SongDTO GetCurrentSong()
        {
            return _memoryCache.Get<SongDTO>(CurrentMusicCacheKey);
        }

        public SongDTO GetLastClickedSong()
        {
            if (_memoryCache.TryGetValue(CurrentMusicCacheKey, out SongDTO song))
            {
                return song;
            }
            return null;
        }
    }
}
