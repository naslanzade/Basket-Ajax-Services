using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla.Areas.Admin.ViewModels.Products;
using Molla.Areas.Admin.ViewModels.Team;
using Molla.Data;
using Molla.Models;

namespace Molla.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<ProductVM> list = new();
            List<Product> products = await _context.Products.Where(m => !m.SoftDeleted).Include(m => m.Category).Include(m=>m.Images).ToListAsync();
            foreach (Product item in products)
            {
                ProductVM model = new()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Category = item.Category,
                    Images = item.Images,

                };

                list.Add(model);
            }
            return View(list);
        }

        [HttpGet]

        public async Task<IActionResult> Detail(int? id)
        {

            if (id is null) return BadRequest();

            Product dbProduct = await _context.Products.Include(m => m.Category).Include(m => m.Images).FirstOrDefaultAsync(m => m.Id == id);

            if (dbProduct is null) return NotFound();

            ProductDetailVM model = new()
            {

                Images = dbProduct.Images,
                Name = dbProduct.Name,
                Category = dbProduct.Category,
                Price=dbProduct.Price,
                Detail=dbProduct.Detail,
                Description=dbProduct.Description,
                Stars=dbProduct.Stars,
                Color=dbProduct.Color,
                CreatedDate = dbProduct.CreatedDate.ToString("MMMM dd, yyyy"),
            };
            return View(model);
        }
    }
}
