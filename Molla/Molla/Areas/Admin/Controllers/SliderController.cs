using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla.Areas.Admin.ViewModels.Slider;
using Molla.Areas.Admin.ViewModels.Team;
using Molla.Data;
using Molla.Models;

namespace Molla.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;

        public SliderController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<SliderVM> list = new();
            List<Slider> sliders = await _context.Sliders.Where(m => !m.SoftDeleted).ToListAsync();
            foreach (Slider item in sliders)
            {
                SliderVM model = new()
                {
                    Id = item.Id,
                    SliderImage = item.SliderImage,                   

                };

                list.Add(model);
            }
            return View(list);
        }

        [HttpGet]

        public async Task<IActionResult> Detail(int? id)
        {

            if (id is null) return BadRequest();

            Slider dbSlider = await _context.Sliders.FirstOrDefaultAsync(m => m.Id == id);

            if (dbSlider is null) return NotFound();

            SliderDetailVM model = new()
            {

                SliderImage = dbSlider.SliderImage,
                Context=dbSlider.Context,
                Title = dbSlider.Title,
                Price = dbSlider.Price,
                ContextSecond = dbSlider.ContextSecond,
                CreatedDate = dbSlider.CreatedDate.ToString("MMMM dd, yyyy"),
            };
            return View(model);
        }
    }
}
