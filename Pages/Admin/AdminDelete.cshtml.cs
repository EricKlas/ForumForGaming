using ForumForGaming.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ForumForGaming.Pages.Admin
{
    public class AdminDeleteModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public AdminDeleteModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public List<MainCategory> MainCategories { get; set; }
        [BindProperty]
        public int MainCategoryId { get; set; }
        public List<SubCategory> SubCategories { get; set; }
        [BindProperty]
        public int SubCategoryId { get; set; }
        public string? DeleteItem { get; set; }

        public async Task OnGetAsync(string CreateItem)
        {
            MainCategories = await _context.MainCategory.ToListAsync();
            SubCategories = await _context.SubCategory.ToListAsync();
            DeleteItem = CreateItem;
        }

        public async Task<IActionResult> OnPostAsync(string delete)
        {
            if (delete == "Archive MainCategory" && MainCategoryId > 0)
            {
                var mainCategory = await _context.MainCategory.FindAsync(MainCategoryId);
                if (mainCategory != null)
                {
                    mainCategory.Archived = true;
                    await _context.SaveChangesAsync();
                }
            }
            else if (delete == "Archive SubCategory" && SubCategoryId > 0)
            {
                var subCategory = await _context.SubCategory.FindAsync(SubCategoryId);
                if (subCategory != null)
                {
                    subCategory.Archived = true;
                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToPage("/Admin/AdminDelete");
        }
    }

}
