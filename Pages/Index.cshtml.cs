using ForumForGaming.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ForumForGaming.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public IndexModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public List<MainCategory> MainCategories { get; set; }
        [BindProperty]
        public MainCategory MainCategory { get; set; }
        public List<SubCategory> SubCategories { get; set; }
        [BindProperty]
        public SubCategory SubCategory { get; set; }
        public List<Post> Posts { get; set; }
        [BindProperty]
        public Post Post { get; set; }
        public List<Comment> Comments { get; set; }
        public int? ReplayId { get; set; }

        [BindProperty]
        public Comment Comment { get; set; }

        public async Task OnGetAsync(int subCategoryId, int postId, int deletePostId, int deleteCommentId, int reportCommentId, int replayTextId)
        {
            if (deletePostId != 0)
            {
                var postToBeDeleted = await _context.Post.FindAsync(deletePostId);
                if (postToBeDeleted != null)
                {
                    postToBeDeleted.Archived = true;
                    await _context.SaveChangesAsync();
                }
            }

            if (deleteCommentId != 0)
            {
                var commentToBeDeleted = await _context.Comment.FindAsync(deleteCommentId);
                if (commentToBeDeleted != null)
                {
                    commentToBeDeleted.TextContent = "Comment has been deleted by user!";
                    await _context.SaveChangesAsync();
                }
            }

            if (reportCommentId != 0)
            {
                var commentToBeReported = await _context.Comment.FindAsync(reportCommentId);
                if (commentToBeReported != null)
                {
                    commentToBeReported.Reported = true;
                    await _context.SaveChangesAsync();
                }
            }

            if (replayTextId != 0)
            {
                ReplayId = replayTextId;
            }

            MainCategories = await _context.MainCategory.ToListAsync();
            SubCategories = await _context.SubCategory.ToListAsync();
            Posts = await _context.Post.ToListAsync();
            Comments = await _context.Comment.ToListAsync();

            if (subCategoryId != 0)
            {
                SubCategory = SubCategories.FirstOrDefault(s => s.Id == subCategoryId);
            }
            if (postId != 0)
            {
                Post = Posts.FirstOrDefault(p => p.Id == postId);
            }
        }

        public async Task<IActionResult> OnPostAsync(string add, int subCategoryId, int postId, int? replyToId)
        {
            switch (add)
            {
                case "Post Comment":
                    Comment.Reported = false;
                    Comment.Date = DateTime.Now;
                    Comment.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    Comment.PostId = postId;
                    if (replyToId != null)
                    {
                        Comment.ReplyToId = replyToId;
                    }
                    _context.Comment.Add(Comment);
                    await _context.SaveChangesAsync();
                    break;

                case "Create Maincategory":
                    _context.MainCategory.Add(MainCategory);
                    await _context.SaveChangesAsync();
                    break;

                case "Create Post":
                    Post.CreatedDate = DateTime.Now;
                    Post.Reported = false;
                    Post.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    Post.SubCategoryId = subCategoryId;
                    _context.Post.Add(Post);
                    await _context.SaveChangesAsync();
                    break;

                case "Create SubCategory":
                    _context.SubCategory.Add(SubCategory);
                    await _context.SaveChangesAsync();
                    break;
            }

            return RedirectToPage("./Index", new { subCategoryId, postId });
        }
    }
}