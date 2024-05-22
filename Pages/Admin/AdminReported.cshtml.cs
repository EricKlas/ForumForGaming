using ForumForGaming.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ForumForGaming.Pages.Admin
{


    [Authorize(Roles = "Admin")]
    public class AdminReportedModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public AdminReportedModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Post> Posts { get; set; }
        [BindProperty]
        public Post Post { get; set; }
        public List<Comment> Comments { get; set; }
        public Comment Comment { get; set; }
        public string? ReportedCategory { get; set; }

        public async Task OnGetAsync(string reportedCategory)
        {
            Posts = await _context.Post.ToListAsync();
            Comments = await _context.Comment.ToListAsync();

            if (reportedCategory != null)
            {
                ReportedCategory = reportedCategory;
            }
            else
            {
                ReportedCategory = null;
            }
        }

        public async Task<IActionResult> OnPostAsync(string reported, int? CommentId, int? PostId)
        {
            if (reported == "Ignore")
            {
                if(CommentId != null)
                {
                    var comment = await _context.Comment.FindAsync(CommentId.Value);
                    if (comment != null)
                    {
                        comment.Reported = false;
                        _context.Comment.Update(comment);
                        await _context.SaveChangesAsync();
                    }
                }
                else if(PostId != null)
                {
                    var post = await _context.Post.FindAsync(PostId.Value);
                    if (post != null)
                    {
                        post.Reported = false;
                        _context.Post.Update(post);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            else if (reported == "Delete")
            {
                if(CommentId != null)
                {
                    var comment = await _context.Comment.FindAsync(CommentId.Value);
                    if(comment != null)
                    {
                        comment.TextContent = "Comment has been deleted!";
                        comment.Reported = false;
                        _context.Comment.Update(comment);
                        await _context.SaveChangesAsync();
                    }
                }
                else if (PostId != null)
                {
                    var post = await _context.Post.FindAsync(PostId.Value);
                    if (post != null)
                    {
                        _context.Post.Remove(post);
                        await _context.SaveChangesAsync();
                    }
                }
            }

            return RedirectToPage("/Admin/AdminReported");
        }
    }
}
