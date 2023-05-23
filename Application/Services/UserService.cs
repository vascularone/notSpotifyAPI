using NotSpotifyAPI.Application.Common.Interfaces.Repositories;
using NotSpotifyAPI.Application.Common.Interfaces.Services;
using NotSpotifyAPI.Domain.Models;

namespace NotSpotifyAPI.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public List<User> getAll()
        {
            return _userRepository.GetAll();
        }

        public User getUserById(int id)
        {
            return _userRepository.getUserById(id);
        }
    }
}
