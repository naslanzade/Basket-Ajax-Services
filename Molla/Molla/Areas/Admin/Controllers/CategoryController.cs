using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla.Areas.Admin.ViewModels.Blog;
using Molla.Areas.Admin.ViewModels.Categories;
using Molla.Data;
using Molla.Models;

namespace Molla.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<CategoryVM> list = new();
            List<Category> categories= await _context.Categories.Where(m => !m.SoftDeleted).ToListAsync();
            foreach (Category item in categories)
            {
                CategoryVM model = new()
                {
                    Id = item.Id,
                    Name = item.Name,
                };

                list.Add(model);
            }
            return View(list);
        }

        [HttpGet]

        public async Task<IActionResult> Detail(int? id)
        {

            if (id is null) return BadRequest();

            Category dbCategory = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);

            if (dbCategory is null) return NotFound();

            CategoryDetailVM model = new()
            {
                Name = dbCategory.Name,
                CreatedDate = dbCategory.CreatedDate.ToString("MMMM dd, yyyy"),
            };
            return View(model);
        }
    }
}
