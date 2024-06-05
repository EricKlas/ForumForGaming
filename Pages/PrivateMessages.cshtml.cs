using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ForumForGaming.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ForumForGaming.Pages
{
    public class PrivateMessagesModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;
        public PrivateMessagesModel(Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public List<PrivateMessage> PrivateMessages { get; set; } = new List<PrivateMessage>();
        [BindProperty]
        public PrivateMessage? PrivateMessage { get; set; }
        public bool SendMessage { get; set; } = false;

        public async Task OnGetAsync(int? PrivateMessageId, string? sendMessage)
        {
            PrivateMessages = await _context.PrivateMessage.ToListAsync();

            if (PrivateMessageId != null)
            {
                PrivateMessage = await _context.PrivateMessage.FindAsync(PrivateMessageId);
            }
            else
            {
                PrivateMessage = null;
            }

            SendMessage = sendMessage != null;
        }

        public async Task<IActionResult> OnPostAsync(string senderId)
        {
            if (PrivateMessage != null)
            {
                var receiver = await _userManager.FindByNameAsync(PrivateMessage.ReciverId);
                if (receiver != null)
                {
                    PrivateMessage.ReciverId = receiver.Id;
                    PrivateMessage.Date = DateTime.Now;
                    PrivateMessage.SenderId = senderId;

                    _context.PrivateMessage.Add(PrivateMessage);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToPage("/PrivateMessages");
        }
    }
}
