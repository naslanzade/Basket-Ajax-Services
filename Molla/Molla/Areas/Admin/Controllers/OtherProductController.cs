using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla.Areas.Admin.ViewModels.Blog;
using Molla.Areas.Admin.ViewModels.OtherProduct;
using Molla.Data;
using Molla.Models;

namespace Molla.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OtherProductController : Controller
    {
        private readonly AppDbContext _context;

        public OtherProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<OtherProductVM> list = new();
            List<OtherProduct> products = await _context.OtherProducts.Where(m => !m.SoftDeleted).ToListAsync();
            foreach (OtherProduct item in products)
            {
                OtherProductVM model = new()
                {
                    Id = item.Id,
                    Image = item.Image,
                    Heading = item.Heading,
                };

                list.Add(model);
            }
            return View(list);
        }

        [HttpGet]

        public async Task<IActionResult> Detail(int? id)
        {

            if (id is null) return BadRequest();

            OtherProduct dbProduct = await _context.OtherProducts.FirstOrDefaultAsync(m => m.Id == id);

            if (dbProduct is null) return NotFound();

            OtherProductDetailVM model = new()
            {

                Image = dbProduct.Image,
                Heading = dbProduct.Heading,
                Description= dbProduct.Description,
                Title = dbProduct.Title,
                CreatedDate = dbProduct.CreatedDate.ToString("MMMM dd, yyyy"),
            };
            return View(model);
        }
    }
}
