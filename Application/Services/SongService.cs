
using Application.Common.Interfaces.Repositories;
using NotSpotify.Application.Common.Interfaces.Services;
using NotSpotifyAPI.Domain.Models;

namespace NotSpotifyAPI.Application.Services
{
    public class SongService : ISongService
    {
        private readonly ISongRepository _songRepository;

        public SongService(ISongRepository songRepository)
        {
            _songRepository = songRepository;
        }
        public List<SongDTO> GetAllSongs()
        {
            var songs = _songRepository.GetAllSongs().Select(x => new SongDTO { Id = x.Id, Name = x.Name, Artist = x.Artist, LinkRef = x.LinkRef});

            return songs.ToList();
        }

        public Song GetSongById(int id)
        {
            var song = _songRepository.GetSong(id);
            return song;
        }

        public CurrentSong SetCurrentSong(int id, SongDTO song)
        {
            var s = _songRepository.UpdateCurrentSong(id, song);
            return s;
        }

        public CurrentSong GetCurrentSong()
        {
            var song = _songRepository.GetCurrentSong();
            return song;
        }

    }
}
