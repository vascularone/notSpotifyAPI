using Application.Common.Interfaces.Repositories;
using Application.Extensions;
using NotSpotify.Application.Common.Interfaces.Services;
using NotSpotifyAPI.Application.Common.Interfaces.Repositories;
using NotSpotifyAPI.Domain.DTO;
using NotSpotifyAPI.Domain.Models;

namespace NotSpotifyAPI.Application.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IPlaylistRepository _playlistRepository;
        private readonly IUserPlaylistRepository _userPlaylistRepository;

        public PlaylistService(IPlaylistRepository playlistRepository, IUserPlaylistRepository userPlaylistRepository)
        {
            _playlistRepository = playlistRepository;
            _userPlaylistRepository = userPlaylistRepository;
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

        public Playlist CreatePlaylist(PlaylistDTO playlist)
        {
                var entry = new Playlist
                {
                    Name = playlist.Name,
                    Description = playlist.Description,
                    LinkRef = playlist.LinkRef,
                };
                _playlistRepository.Insert(entry);
                _playlistRepository.SaveChanges();
                return entry;
        }

        public bool DeletePlaylist(int playlistId)
        {
            var playlist = _playlistRepository.GetPlaylistById(playlistId);
            if (playlist == null)
                return false;
            _playlistRepository.Delete(playlist);
            _playlistRepository.SaveChanges();
            return true;
        }
	}
}
