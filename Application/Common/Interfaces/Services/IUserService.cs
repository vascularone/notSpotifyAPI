using NotSpotifyAPI.Domain.Models;

namespace NotSpotifyAPI.Application.Common.Interfaces.Services
{
    public interface IUserService 
    {
        User getUserById(int id);
        List<User> getAll();
        User CreateUser(UserDTO user);
        bool editUser(int id, UserDTO user);
        bool login(UserLoginDTO user);
    }
}
