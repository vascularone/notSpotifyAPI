﻿using Application.Common.DTO;
using Application.Extensions;
using Microsoft.AspNetCore.Mvc;
using NotSpotify.Application.Common.Interfaces.Services;
using NotSpotifyAPI.Application.Services;
using NotSpotifyAPI.Domain.DTO;
using NotSpotifyAPI.Domain.Models;

namespace NotSpotifyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistController : Controller
    {
        private readonly IPlaylistService _playlistService;
        private readonly ILogger<SongsController> _logger;
        private readonly IHttpContextAccessor _contextAccessor;
        public PlaylistController(IPlaylistService playlistService, IHttpContextAccessor contextAccessor, ILogger<SongsController> logger)
        {
            _playlistService = playlistService;
            _contextAccessor = contextAccessor;
            _logger = logger;
        }

        [HttpGet("GetPlaylistsByUserId")]
        public IActionResult GetPlaylistsByUserId(int userId)
        {
            try
            {
                _logger.LogDetailedInformation("Retreiving songs", _contextAccessor);
                var playlist = _playlistService.GetPlaylistByUserId(userId);
                if (playlist == null)
                {
                    return NotFound("No Playlist found");
                }
                return Ok(new ResponseDTO<List<Playlist>> { Data = playlist });
            }
            catch (Exception ex)
            {
                _logger.LogDetailedError(ex, string.Empty, _contextAccessor);
                return BadRequest(ex.Message);
            }
        }

         [HttpGet("GetAllPlaylists")]
        public IActionResult GetAllPlaylists()
        {
            try
            {
                _logger.LogDetailedInformation("Retreiving playlists", _contextAccessor);
                var playlist = _playlistService.GetAllPlaylists();
                if (playlist == null)
                {
                    return NotFound("No Playlists found");
                }
                return Ok(new ResponseDTO<List<Playlist>> { Data = playlist });
            }
            catch (Exception ex)
            {
                _logger.LogDetailedError(ex, string.Empty, _contextAccessor);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetPlaylistById")]
        public IActionResult GetPlaylistById(int id)
        {
            try
            {
                _logger.LogDetailedInformation("Retreiving playlist", _contextAccessor);
                var playlist = _playlistService.GetPlaylistById(id);

                return Ok(new ResponseDTO<Playlist> { Data = playlist });
            }
            catch (Exception ex)
            {
                _logger.LogDetailedError(ex, string.Empty, _contextAccessor);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetSongsByPlaylistId")]
        public IActionResult GetSongsByPlaylistId(int id)
        {
            try
            {
                _logger.LogDetailedInformation("Retreiving playlist", _contextAccessor);
                var playlist = _playlistService.GetSongsByPlaylistId(id);

                return Ok(new ResponseDTO<List<Song>> { Data = playlist });
            }
            catch (Exception ex)
            {
                _logger.LogDetailedError(ex, string.Empty, _contextAccessor);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public IActionResult CreatePlaylist(PlaylistDTO playlist, int userId)
        {
            try
            {
                _logger.LogDetailedInformation("Creating playlist", _contextAccessor);
                var entry = _playlistService.CreatePlaylist(playlist, userId);
                return Ok(new ResponseDTO<Playlist> { Data = entry });
            }
            catch (Exception ex)
            {
                _logger.LogDetailedError(ex, string.Empty, _contextAccessor);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("[action]")]
        public IActionResult DeletePlaylist(int id)
        {
            try
            {
                _logger.LogDetailedInformation("Deleting playlist", _contextAccessor);
                var entry = _playlistService.DeletePlaylist(id);

                return Ok(new ResponseDTO<bool> { Data = entry });
            }
            catch (Exception ex)
            {
                _logger.LogDetailedError(ex, string.Empty, _contextAccessor);
                return BadRequest(ex.Message);
            }
        }
    }
}
