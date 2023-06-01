using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla.Areas.Admin.ViewModels.ProductImages;
using Molla.Areas.Admin.ViewModels.Team;
using Molla.Data;
using Molla.Models;

namespace Molla.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductImagesController : Controller
    {
        private readonly AppDbContext _context;

        public ProductImagesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<ProductImageVM> list = new();
            List<ProductImage> images = await _context.ProductImages.Where(m => !m.SoftDeleted).ToListAsync();
            foreach (ProductImage item in images)
            {
                ProductImageVM model = new()
                {
                    Id = item.Id,
                    Image = item.Image,
                   
                };

                list.Add(model);
            }
            return View(list);
        }

        [HttpGet]

        public async Task<IActionResult> Detail(int? id)
        {

            if (id is null) return BadRequest();

            ProductImage dbImage = await _context.ProductImages.Include(m => m.Product).FirstOrDefaultAsync(m => m.Id == id);

            if (dbImage is null) return NotFound();

            ProductImageDetailVM model = new()
            {

                Image = dbImage.Image,
                Product = dbImage.Product,
                CreatedDate = dbImage.CreatedDate.ToString("MMMM dd, yyyy"),
            };
            return View(model);
        }
    }
}
