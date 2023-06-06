using Domain.Common;

namespace NotSpotifyAPI.Domain.Models
{
    public class Song : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string LinkRef { get; set; }
        

    }
}
