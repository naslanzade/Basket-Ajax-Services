using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla.Areas.Admin.ViewModels.Blog;
using Molla.Areas.Admin.ViewModels.BrandInfo;
using Molla.Data;
using Molla.Models;

namespace Molla.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandInfoController : Controller
    {
        private readonly AppDbContext _context;

        public BrandInfoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<BrandInfoVM> list = new();
            List<BrandInfo> infos = await _context.BrandInfos.Where(m => !m.SoftDeleted).ToListAsync();
            foreach (BrandInfo info in infos)
            {
                BrandInfoVM model = new()
                {
                    Id = info.Id,
                    Title = info.Title,                   

                };

                list.Add(model);
            }
            return View(list);
        }

        [HttpGet]

        public async Task<IActionResult> Detail(int? id)
        {

            if (id is null) return BadRequest();

            BrandInfo dbInfo = await _context.BrandInfos.FirstOrDefaultAsync(m => m.Id == id);

            if (dbInfo is null) return NotFound();

            BrandInfoDetailVM model = new()
            {               
                Title = dbInfo.Title,
                Description = dbInfo.Description,
                CreatedDate = dbInfo.CreatedDate.ToString("MMMM dd, yyyy"),
            };
            return View(model);
        }
    }
}
