using ForumForGaming.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ForumForGaming.Pages.Admin
{

    [Authorize(Roles = "Admin")]
    public class AdminCreateModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public AdminCreateModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public List<MainCategory> MainCategories { get; set; }
        [BindProperty]
        public MainCategory MainCategory { get; set; }
        public List<SubCategory> SubCategories { get; set; }
        [BindProperty]
        public SubCategory SubCategory { get; set; }

        public string? AddItem { get; set; }

        public async Task OnGetAsync(string CreateItem)
        {
            MainCategories = await _context.MainCategory.ToListAsync();
            SubCategories = await _context.SubCategory.ToListAsync();

            if (CreateItem != null)
            {
                AddItem = CreateItem;
            }
            else
            {
                AddItem = null;
            }
        }

        public async Task<IActionResult> OnPostAsync(string add)
        {
            if (add == "Create Maincategory")
            {
                MainCategory.Archived = false;
                _context.MainCategory.Add(MainCategory);
                await _context.SaveChangesAsync();
            }
            else if (add == "Create SubCategory")
            {
                SubCategory.Archived= false;
                _context.SubCategory.Add(SubCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Admin/AdminCreate");
        }
    }
}
