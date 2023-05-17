using Domain.Common;

namespace NotSpotifyAPI.Domain.Models
{
    public class Playlist : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
