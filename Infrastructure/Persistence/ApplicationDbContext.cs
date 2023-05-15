using Microsoft.EntityFrameworkCore;
using NotSpotifyAPI.Domain.Models;

namespace NotSpotifyAPI.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Song> Songs { get; set; }

        public DbSet<Playlist> Playlists { get; set; }
    }
}
