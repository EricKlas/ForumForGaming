namespace ForumForGaming.Models
{
    public class PrivateMessage
    {
        public int Id { get; set; }
        public string TextContent { get; set; }
        public DateTime Date { get; set; }
        public bool Reported { get; set; }
        public int ReciverId { get; set; }
        public int SenderId { get; set; }
    }
}
