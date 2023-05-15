using Microsoft.AspNetCore.Mvc;

namespace NotSpotifyAPI.Controllers
{
    public class PlaylistController : Controller
    {
        public IActionResult CreatePlaylist()
        {
            return View();
        }
    }
}
