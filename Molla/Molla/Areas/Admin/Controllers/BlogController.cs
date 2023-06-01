using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla.Areas.Admin.ViewModels.Blog;
using Molla.Data;
using Molla.Models;

namespace Molla.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            List<BlogVM> list = new();
            List<Blog> blogs = await _context.Blogs.Where(m => !m.SoftDeleted).ToListAsync();
            foreach (Blog blog in blogs)
            {
                BlogVM model = new()
                {
                    Id = blog.Id,
                    Image = blog.BlogImage,
                    Title = blog.Title,
                    CreatedDate = blog.CreatedDate.ToString("MMMM dd, yyyy"),

                };

                list.Add(model);
            }
            return View(list);
        }

        [HttpGet]

        public async Task<IActionResult> Detail(int? id)
        {

            if (id is null) return BadRequest();

            Blog dbBlog = await _context.Blogs.FirstOrDefaultAsync(m => m.Id == id);

            if (dbBlog is null) return NotFound();

            BlogDetailVM model = new()
            {

                BlogImage = dbBlog.BlogImage,
                Author = dbBlog.Author,
                CommentCount=dbBlog.CommentCount,
                Title = dbBlog.Title,
                Description= dbBlog.Description,
                Context=dbBlog.Context,
                TitleSecond=dbBlog.TitleSecond,
                CreatedDate = dbBlog.CreatedDate.ToString("MMMM dd, yyyy"),
            };
            return View(model);
        }
    }
}
