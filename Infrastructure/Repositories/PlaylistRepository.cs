﻿using Application.Common.Interfaces.Repositories;
using Infrastucture.Repositories;
using Microsoft.EntityFrameworkCore;
using NotSpotifyAPI.Domain.Models;
using NotSpotifyAPI.Infrastructure.Persistence;

namespace NotSpotifyAPI.Infrastructure.Repositories
{
    public class PlaylistRepository : BaseRepository<Playlist>, IPlaylistRepository
    {
        public PlaylistRepository(ApplicationDbContext context) : base(context) { }
        public List<Playlist> GetPlaylistsByUserId(int userId)
        {
            var playlistIds = _dbContext.UserPlaylists
                    .Where(up => up.UserId == userId)
                    .Select(up => up.PlaylistId)
                    .ToList();

            var playlists = _dbContext.Playlists
                .Where(p => playlistIds.Contains(p.Id)).ToList();

            return playlists;
        }
        public Playlist GetPlaylistById(int id)
        {
            return this._dbContext.Playlists.FirstOrDefault(a => a.Id == id);
        }

        public List<Song> GetSongsByPlaylistId(int playlistId)
        {
            var playlist = _dbContext.PlaylistSongs
                .Where(i => i.PlaylistId == playlistId)
                .Select(i => i.SongId)
                .ToList();
            var songs = _dbContext.Songs
                .Where(p => playlist.Contains(p.Id)).ToList();
            return songs;
        }
    }
}
