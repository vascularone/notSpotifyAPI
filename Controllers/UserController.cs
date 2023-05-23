using Application.Common.DTO;
using Microsoft.AspNetCore.Mvc;
using NotSpotifyAPI.Application.Services;
using NotSpotifyAPI.Domain.Models;
using Application.Extensions;
using NotSpotify.Application.Common.Interfaces.Services;
using NotSpotifyAPI.Application.Common.Interfaces.Services;

namespace NotSpotifyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger<SongsController> _logger;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserController(IUserService userService, ILogger<SongsController> logger, IHttpContextAccessor contextAccessor)
        {
            _userService = userService;
            _logger = logger;
            _contextAccessor = contextAccessor;
        }

        [HttpGet("[action]")]
        public IActionResult GetAllUsers()
        {
            try
            {
                _logger.LogDetailedInformation("Retreiving Users", _contextAccessor);
                var users = _userService.getAll();
                if (users == null)
                {
                    return NotFound("No users found");
                }
                return Ok(new ResponseDTO<List<User>> { Data = users });
            }
            catch (Exception ex)
            {
                _logger.LogDetailedError(ex, string.Empty, _contextAccessor);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                _logger.LogDetailedInformation("Retreiving user", _contextAccessor);
                var user = _userService.getUserById(id);
                if (user == null)
                {
                    return NotFound("No user found");
                }
                return Ok(new ResponseDTO<User> { Data = user });
            }
            catch (Exception ex)
            {
                _logger.LogDetailedError(ex, string.Empty, _contextAccessor);
                return BadRequest(ex.Message);
            }
        }
    }
}
