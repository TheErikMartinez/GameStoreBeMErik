using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace GameStoreBeMErik.Models
{
    public class VideoGameUser
    {
        public int UserId { get; set; }
        public int VideoGameId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        [JsonIgnore]
        public VideoGame? VideoGame { get; set; }

    }
}
