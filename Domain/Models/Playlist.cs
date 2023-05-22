using Domain.Common;

namespace NotSpotifyAPI.Domain.Models
{
    public class Playlist : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LinkRef { get; set; }
    }
}
