using ForumForGaming.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace ForumForGaming.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class AdminManageRolesModel : PageModel
    {
        [BindProperty]
        public string UserEmail { get; set; }
        public string? ChangeAdmin { get; set; }
        private readonly UserManager<ApplicationUser> _userManager;
        public List<ApplicationUser> AdminUsers { get; private set; }

        public AdminManageRolesModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task OnGetAsync(string changeUser, string removeAdmin)
        {
            if (AdminUsers == null)
            {
                AdminUsers = (await _userManager.GetUsersInRoleAsync("Admin")).ToList();
            }

            if (!string.IsNullOrEmpty(removeAdmin))
            {
                var user = await _userManager.FindByIdAsync(removeAdmin);
                if (user != null)
                {
                    await _userManager.RemoveFromRoleAsync(user, "Admin");
                }
            }

            ChangeAdmin = changeUser;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (UserEmail != null)
            {
                var user = await _userManager.FindByEmailAsync(UserEmail);
                var roleName = "Admin";
                if (user != null)
                {
                    await _userManager.AddToRoleAsync(user, roleName);
                }
            }
            return RedirectToPage("/Admin/AdminManageRoles");
        }
    }
}