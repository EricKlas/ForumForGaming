using Microsoft.AspNetCore.Identity;

namespace ForumForGaming.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string ProfilePicture { get; set; }
    }
}
