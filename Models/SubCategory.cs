namespace ForumForGaming.Models
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MainCategoryId { get; set; }
        public bool? Archived { get; set; }
    }
}
