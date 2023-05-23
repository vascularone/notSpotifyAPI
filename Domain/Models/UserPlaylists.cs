using Domain.Common;

namespace NotSpotifyAPI.Domain.Models
{
    public class UserPlaylists : BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PlaylistId { get; set; }

        public virtual User User { get; set; }
        public virtual List<Playlist> Playlist { get; set; }

    }
}
