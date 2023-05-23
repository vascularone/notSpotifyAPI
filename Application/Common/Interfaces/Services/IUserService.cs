using NotSpotifyAPI.Domain.Models;

namespace NotSpotifyAPI.Application.Common.Interfaces.Services
{
    public interface IUserService 
    {
        User getUserById(int id);

        List<User> getAll();
    }
}
