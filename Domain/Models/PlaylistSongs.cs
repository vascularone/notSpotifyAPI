namespace NotSpotifyAPI.Domain.Models
{
    public class PlaylistSongs
    {
        public int Id { get; set; }
        public int PlaylistId { get; set; }
        public int SongId { get; set; }
    }
}
