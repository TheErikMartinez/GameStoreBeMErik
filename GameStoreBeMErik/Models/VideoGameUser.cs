namespace GameStoreBeMErik.Models
{
    public class VideoGameUser
    {
        public int UserId { get; set; }
        public string VideoGameId { get; set; }
        public User User { get; set; }
        public VideoGame VideoGame { get; set; }

    }
}
