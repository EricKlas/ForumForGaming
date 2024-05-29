namespace ForumForGaming.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Reported { get; set; }
        public int SubCategoryId { get; set; }
        public string? UserId { get; set; }
    }
}
