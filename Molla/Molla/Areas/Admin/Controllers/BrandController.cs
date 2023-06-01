using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla.Areas.Admin.ViewModels.Blog;
using Molla.Areas.Admin.ViewModels.Brand;
using Molla.Data;
using Molla.Models;

namespace Molla.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly AppDbContext _context;

        public BrandController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<BrandVM> list = new();
            List<Brand> brands = await _context.Brands.Where(m => !m.SoftDeleted).ToListAsync();
            foreach (Brand brand in brands)
            {
                BrandVM model = new()
                {
                    Id = brand.Id,
                    Image = brand.Image,
                   

                };

                list.Add(model);
            }
            return View(list);
        }


        [HttpGet]

        public async Task<IActionResult> Detail(int? id)
        {

            if (id is null) return BadRequest();

            Brand dbBrand = await _context.Brands.FirstOrDefaultAsync(m => m.Id == id);

            if (dbBrand is null) return NotFound();

            BrandDetailVM model = new()
            {

                Image = dbBrand.Image,
                CreatedDate = dbBrand.CreatedDate.ToString("MMMM dd, yyyy"),
            };
            return View(model);
        }
    }
}
