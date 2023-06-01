using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla.Areas.Admin.ViewModels.Blog;
using Molla.Areas.Admin.ViewModels.Team;
using Molla.Data;
using Molla.Models;

namespace Molla.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController : Controller
    {
        private readonly AppDbContext _context;

        public TeamController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<TeamVM> list = new();
            List<Team> teams = await _context.Teams.Where(m => !m.SoftDeleted).Include(m=>m.Position).ToListAsync();
            foreach (Team item in teams)
            {
                TeamVM model = new()
                {
                    Id = item.Id,
                    Image = item.Image,
                    FullName = item.FullName,                 

                };

                list.Add(model);
            }
            return View(list);
        }

        [HttpGet]

        public async Task<IActionResult> Detail(int? id)
        {

            if (id is null) return BadRequest();

            Team dbTeam = await _context.Teams.Include(m => m.Position).FirstOrDefaultAsync(m => m.Id == id);

            if (dbTeam is null) return NotFound();

            TeamDetailVM model = new()
            {

                Image = dbTeam.Image,
                FullName = dbTeam.FullName,
                Position = dbTeam.Position,
                Comment = dbTeam.Comment,
                CreatedDate = dbTeam.CreatedDate.ToString("MMMM dd, yyyy"),
            };
            return View(model);
        }
    }
}
