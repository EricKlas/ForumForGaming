using ForumForGaming.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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

        public async Task OnGetAsync(string changeItem, int mainCategoryId, int subCategoryId)
        {
            MainCategories = await _context.MainCategory.ToListAsync();
            SubCategories = await _context.SubCategory.ToListAsync();

            MainCategory = await _context.MainCategory.FindAsync(mainCategoryId);
            SubCategory = await _context.SubCategory.FindAsync(subCategoryId);
            if (changeItem != null)
            {
                ChangeItem = changeItem;
            }
            else
            {
                ChangeItem = null;
            }
        }

        public async Task<IActionResult> OnPostAsync(string change)
        {
            if (change == "Change Maincategory")
            {
                _context.MainCategory.Update(MainCategory);
                await _context.SaveChangesAsync();
            }
            else if (change == "Change SubCategory")
            {
                _context.SubCategory.Update(SubCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Admin/AdminChange");
        }
    }
}
