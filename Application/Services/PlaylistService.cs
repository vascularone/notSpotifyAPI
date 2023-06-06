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
        private readonly IUserRepository _userRepository;

        public PlaylistService(IPlaylistRepository playlistRepository, IUserPlaylistRepository userPlaylistRepository, IUserRepository userRepository)
        {
            _playlistRepository = playlistRepository;
            _userPlaylistRepository = userPlaylistRepository;
            _userRepository = userRepository;
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

        public List<Playlist> GetAllPlaylists()
        {
            var playlists = _playlistRepository.GetAllPlaylists();
            return playlists;
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

        public Playlist CreatePlaylist(PlaylistDTO playlist, int userId)
        {
            var entry = new Playlist
            {
                Name = playlist.Name,
                Description = playlist.Description,
                LinkRef = playlist.LinkRef,
            };

            _playlistRepository.Insert(entry);

            var user = _userRepository.getUserById(userId);

            var secondEntry = new UserPlaylists
            {
                User = user,
                UserId = userId,
                PlaylistId = entry.Id,
            };

            user.Playlist.Add(entry); // Add the UserPlaylists entry to the user's UserPlaylists collection

            secondEntry.Playlist = entry;

            _userPlaylistRepository.Insert(secondEntry);
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
