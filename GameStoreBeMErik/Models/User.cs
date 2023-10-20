using System.ComponentModel.DataAnnotations;

namespace GameStoreBeMErik.Models
{
    public class User
    {

        public int Id { get; set; }
        [EmailAddress, MaxLength(150)]
        public string Email { get; set; }
        [MaxLength(255)]
        public string PasswordHash { get; set; }

    }
}
