using System.Text.Json.Serialization;

namespace ForumForGaming.Models
{
    public class DatabaseInfo
    {
        [JsonPropertyName("mainCategoryCount")]
        public int MainCategoryCount { get; set; }

        [JsonPropertyName("subCategoryCount")]
        public int SubCategoryCount { get; set; }

        [JsonPropertyName("postCount")]
        public int PostCount { get; set; }

        [JsonPropertyName("commentCount")]
        public int CommentCount { get; set; }

        [JsonPropertyName("registratedUserCount")]
        public int RegistratedUserCount { get; set; }

        [JsonPropertyName("archivedMainCategoryCount")]
        public int ArchivedMainCategoryCount { get; set; }

        [JsonPropertyName("archivedSubCategoryCount")]
        public int ArchivedSubCategoryCount { get; set; }
    }
}
