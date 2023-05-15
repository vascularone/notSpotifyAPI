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
                return Ok(new ResponseDTO<Song> {  Data = songDTO });
            }
            catch (Exception ex)
            {
                _logger.LogDetailedError(ex, string.Empty, _contextAccessor);
                return BadRequest(ex.Message);
            }
        }

    }
}
