namespace ForumForGaming.Models
{
    public class PrivateMessage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TextContent { get; set; }
        public DateTime Date { get; set; }
        public string ReciverId { get; set; }
        public string SenderId { get; set; }
    }
}
