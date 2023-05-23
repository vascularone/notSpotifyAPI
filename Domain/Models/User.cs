using Domain.Common;

namespace NotSpotifyAPI.Domain.Models
{
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username {  get; set; }
        public string Role { get; set; }
        public virtual List<UserPlaylists> UserPlaylists { get; set; }



    }
}
