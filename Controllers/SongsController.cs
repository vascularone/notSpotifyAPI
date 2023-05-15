using Microsoft.AspNetCore.Mvc;
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
            var response = new { message = "this works!" };
            return Ok(response);
        }
    }
}
