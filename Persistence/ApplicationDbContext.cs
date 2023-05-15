using Microsoft.EntityFrameworkCore;
using NotSpotifyAPI.Models;

namespace NotSpotifyAPI.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Song> Songs { get; set; }
    }
}
