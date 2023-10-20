using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.ComponentModel.DataAnnotations;

namespace GameStoreBeMErik.Models
{
    public enum type { Akció, Kaland, Coop, Oktató, Túlélő }
    public class VideoGame
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        public type Type { get; set; }
        public int Price { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }

    }
}
