using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla.Data;
using Molla.Models;
using Molla.Services.Interface;
using Molla.ViewModels;

namespace Molla.Controllers
{
    public class ProductController : Controller
    {

        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int ? id)
        {

            if (id is null) return BadRequest();

            Product product = await _context.Products.Include(m => m.Images).Include(m => m.Category).Where(m => !m.SoftDeleted).FirstOrDefaultAsync(x => x.Id == id);

            if (product is null) return NotFound();

            ProductDetailVM model = new()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Images = product.Images.ToList()
            };

            return View(model);
        }
    }
}
