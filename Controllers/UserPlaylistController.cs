using Application.Common.DTO;
using Microsoft.AspNetCore.Mvc;
using NotSpotifyAPI.Application.Services;
using NotSpotifyAPI.Domain.Models;
using Application.Extensions;
using NotSpotify.Application.Common.Interfaces.Services;
using NotSpotifyAPI.Application.Common.Interfaces.Services;
using NotSpotifyAPI.Application.Common.Interfaces.Repositories;

namespace NotSpotifyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserPlaylist : Controller
    {
        private readonly IUserPlaylistRepository _userPlaylistRepository;
        private readonly ILogger<UserPlaylist> _logger;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserPlaylist(IUserPlaylistRepository userPlaylistRepo, ILogger<UserPlaylist> logger, IHttpContextAccessor contextAccessor)
        {
            _userPlaylistRepository = userPlaylistRepo;
            _logger = logger;
            _contextAccessor = contextAccessor;
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            try
            {
                _logger.LogDetailedInformation("Retreiving UserPlaylist", _contextAccessor);
                var users = _userPlaylistRepository.GetAll();
                if (users == null)
                {
                    return NotFound("No users found");
                }
                return Ok(new ResponseDTO<List<UserPlaylists>> { Data = users });
            }
            catch (Exception ex)
            {
                _logger.LogDetailedError(ex, string.Empty, _contextAccessor);
                return BadRequest(ex.Message);
            }
        }

        }
    }
