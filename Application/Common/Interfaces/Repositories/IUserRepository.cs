using Application.Common.Interfaces.Repositories;
using Infrastucture.Repositories;
using NotSpotifyAPI.Domain.Models;

namespace NotSpotifyAPI.Application.Common.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        List<User> GetAll();
        User getUserById(int id);
    }
}
