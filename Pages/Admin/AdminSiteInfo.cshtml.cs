using ForumForGaming.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForumForGaming.Pages.Admin
{
    public class AdminSiteInfoModel : PageModel
    {
        public DatabaseInfo DatabaseInfo { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            DatabaseInfo = await DAL.DatabaseInfoAPI.GetDatabaseInfo();
            return Page();
        }
    }
}
