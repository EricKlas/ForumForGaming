using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForumForGaming.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class AdminManageRolesModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
