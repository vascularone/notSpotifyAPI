using Domain.Common;

namespace NotSpotifyAPI.Domain.Models
{
    public class Playlist : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string LinkRef { get; set; }

        public ICollection<UserPlaylists> UserPlaylists { get; set; }
    }
}
