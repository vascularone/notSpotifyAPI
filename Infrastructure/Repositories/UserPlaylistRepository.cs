using Application.Common.Interfaces.Repositories;
using Infrastucture.Repositories;
using NotSpotifyAPI.Application.Common.Interfaces.Repositories;
using NotSpotifyAPI.Domain.Models;
using NotSpotifyAPI.Infrastructure.Persistence;

namespace NotSpotifyAPI.Infrastructure.Repositories
{
    public class UserPlaylistRepository : BaseRepository<UserPlaylists>, IUserPlaylistRepository
    {
        public UserPlaylistRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
