namespace NotSpotifyAPI.Domain.Models
{
    public class UserPlaylists
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PlaylistId { get; set; }

        public virtual Playlist Playlist { get; set; }
    }
}
