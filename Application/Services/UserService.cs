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

        public User CreateUser(UserDTO user)
        {
            var entry = new User 
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Username = user.Username,
                Playlist = null,
            };

            _userRepository.Insert(entry);
            _userRepository.SaveChanges();
            return entry;
        }

        public bool editUser(int id, UserDTO user)
        {
            var entry = _userRepository.getUserById(id);
            if (entry == null)
               return false;
            entry.Email = user.Email;
            entry.Username = user.Username;
            entry.Name = user.Name;
            entry.Password = user.Password;
            _userRepository.SaveChanges();
            return true;
        } 

        public bool login(UserLoginDTO user)
        {
            var users = _userRepository.GetAll();
            var entry = users.FirstOrDefault(p => p.Username == user.Username && p.Password == user.Password);
            if (entry == null)
            {
                return false;
            }
            return true;
            
        }
	}
}
