namespace ForumForGaming.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string TextContent { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ReplyToId { get; set; }
        public bool Reported { get; set; }
        public int? PostId { get; set; }
        public string? UserId { get; set; }
    }
}
