using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForumForGaming.Pages.Admin
{

    [Authorize(Roles = "Admin")]
    public class AdminReportedModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
