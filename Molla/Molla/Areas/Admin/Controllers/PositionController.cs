using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla.Areas.Admin.ViewModels.Positions;
using Molla.Areas.Admin.ViewModels.Team;
using Molla.Data;
using Molla.Models;

namespace Molla.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PositionController : Controller
    {
        private readonly AppDbContext _context;

        public PositionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task< IActionResult> Index()
        {
            List<PositionVM> list = new();
            List<Position> positions = await _context.Positions.Where(m => !m.SoftDeleted).ToListAsync();
            foreach (Position item in positions)
            {
                PositionVM model = new()
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

            Position dbPosition = await _context.Positions.FirstOrDefaultAsync(m => m.Id == id);

            if (dbPosition is null) return NotFound();

            PositionDetailVM model = new()
            {               
                Name = dbPosition.Name,               
                CreatedDate = dbPosition.CreatedDate.ToString("MMMM dd, yyyy"),
            };
            return View(model);
        }
    }
}
