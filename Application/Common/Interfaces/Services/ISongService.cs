using Application.Common.DTO;
using NotSpotifyAPI.Domain.Models;

namespace NotSpotify.Application.Common.Interfaces.Services
{
    public interface ISongService
    {
        Song GetSongById(int id);
        List<SongDTO> GetAllSongs();
        void SetCurrentSong(SongDTO song);
        SongDTO GetCurrentSong();
        SongDTO GetLastClickedSong();
    }
}
