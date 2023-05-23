using Application.Common.DTO;
using Microsoft.AspNetCore.Mvc;
using NotSpotifyAPI.Application.Services;
using NotSpotifyAPI.Domain.Models;
using Application.Extensions;
using NotSpotify.Application.Common.Interfaces.Services;

namespace NotSpotifyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongsController : Controller
    {
        private readonly ISongService _songService;
        private readonly ILogger<SongsController> _logger;
        private readonly IHttpContextAccessor _contextAccessor;

        public SongsController(ISongService songService, ILogger<SongsController> logger, IHttpContextAccessor contextAccessor)
        {
            _songService = songService;
            _logger = logger;
            _contextAccessor = contextAccessor;
        }


        // GET: SongsController
        [HttpGet("GetAllSongs")]
        public IActionResult GetAllSongs()
        {
            try
            {
                _logger.LogDetailedInformation("Retreiving songs", _contextAccessor);
                var songDTOs = _songService.GetAllSongs();

                return Ok(new ResponseDTO<List<SongDTO>> { Data = songDTOs });
            }
            catch (Exception ex)
            {
                _logger.LogDetailedError(ex, string.Empty, _contextAccessor);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetSongById")]
        public IActionResult GetSongById(int id)
        {
            try
            {
                _logger.LogDetailedInformation("Retreiving song", _contextAccessor);
                var songDTO = _songService.GetSongById(id);
                return Ok(new ResponseDTO<Song> { Data = songDTO });
            }
            catch (Exception ex)
            {
                _logger.LogDetailedError(ex, string.Empty, _contextAccessor);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SetCurrentSong")]
        public IActionResult SetCurrentSong(int id, SongDTO song)
        {
            try
            {
                _logger.LogDetailedInformation("Retreiving song", _contextAccessor);
                _songService.SetCurrentSong(id, song);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogDetailedError(ex, string.Empty, _contextAccessor);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetCurrentSong")]
        public IActionResult GetCurrentSong()
        {
            try
            {
                _logger.LogDetailedInformation("Retreiving song", _contextAccessor);
                var currentSong = _songService.GetCurrentSong();
                return Ok(new ResponseDTO<CurrentSong> { Data = currentSong });
            }
            catch (Exception ex)
            {
                _logger.LogDetailedError(ex, string.Empty, _contextAccessor);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public IActionResult CreateSong(SongDTO song)
        {
            try
            {
                _logger.LogDetailedInformation("Creating song", _contextAccessor);
                var entry = _songService.CreateSong(song);
                return Ok(new ResponseDTO<Song> { Data = entry });
            } catch (Exception ex)
            {
                _logger.LogDetailedError(ex, string.Empty, _contextAccessor);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("[action]")]
        public IActionResult DeleteSong(int id)
        {
            try
            {
                _logger.LogDetailedInformation("Deleting song", _contextAccessor);
                var entry = _songService.DeleteSong(id);
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
