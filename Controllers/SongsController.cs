using Microsoft.AspNetCore.Mvc;
using NotSpotifyAPI.Models;
using NotSpotifyAPI.Persistence;

namespace NotSpotifyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public SongsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: SongsController
        [HttpGet("GetSong")]
        public IActionResult GetString()
        {
            var songs = _dbContext.Songs.ToList();
            return Ok(songs);
        }

        [HttpPost("CreateSong")]
        public IActionResult CreateSong(Song song)
        {
            var entry = _dbContext.Songs.Add(new Song
            {
                Artist = song.Artist,
                Id = song.Id,
                Name = song.Name,
            });
            _dbContext.SaveChanges();
            return Ok(entry);
        }
    }
}
