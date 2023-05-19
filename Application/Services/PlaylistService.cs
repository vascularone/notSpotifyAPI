using Application.Common.Interfaces.Repositories;
using NotSpotify.Application.Common.Interfaces.Services;
using NotSpotifyAPI.Domain.DTO;
using NotSpotifyAPI.Domain.Models;

namespace NotSpotifyAPI.Application.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IPlaylistRepository _playlistRepository;

        public PlaylistService(IPlaylistRepository playlistRepository)
        {
            _playlistRepository = playlistRepository;
        }
        public Playlist GetPlaylistById(int id)
        {
            var playlist = this._playlistRepository.GetPlaylistById(id);
            if (playlist == null)
            {
                return null;
            }
            return playlist;
        }
        public List<Playlist> GetPlaylistByUserId(int userId)
        {
            var playList = _playlistRepository.GetPlaylistsByUserId(userId);
            if(playList == null)
            {
                return null;
            }
            return playList;
        }

		public List<Song> GetSongsByPlaylistId(int playlistId)
		{
			var songs = _playlistRepository.GetSongsByPlaylistId(playlistId);
            if(songs == null)
            {
                return null;
            }
            return songs;
		}
	}
}
