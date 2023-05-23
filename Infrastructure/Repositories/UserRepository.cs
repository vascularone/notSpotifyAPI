using Application.Common.Interfaces.Repositories;
using Infrastucture.Repositories;
using NotSpotifyAPI.Application.Common.Interfaces.Repositories;
using NotSpotifyAPI.Domain.Models;
using NotSpotifyAPI.Infrastructure.Persistence;
namespace NotSpotifyAPI.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public User getUserById(int id)
        {
            return _dbContext.Users.Where(p => p.Deleted == false).FirstOrDefault(c => c.Id == id);
        }

        public List<User> GetAll()
        {
            return _dbContext.Users.Where(p => p.Deleted == false).ToList();
        }
    }
}
