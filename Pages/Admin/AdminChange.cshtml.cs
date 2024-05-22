using ForumForGaming.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;

namespace ForumForGaming.Pages.Admin
{

    [Authorize(Roles = "Admin")]
    public class AdminChangeModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public AdminChangeModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public List<MainCategory> MainCategories { get; set; }
        [BindProperty]
        public MainCategory MainCategory { get; set; }
        public List<SubCategory> SubCategories { get; set; }
        [BindProperty]
        public SubCategory SubCategory { get; set; }
        public string? ChangeItem { get; set; }

            public async Task OnGetAsync(string changeItem)
        {
            MainCategories = await _context.MainCategory.ToListAsync();
            SubCategories = await _context.SubCategory.ToListAsync();

            if (ChangeItem != null)
            {
                ChangeItem = ChangeItem;
            }
            else
            {
                ChangeItem = null;
            }
        }
    }
}
