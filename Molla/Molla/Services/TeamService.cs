using Microsoft.EntityFrameworkCore;
using Molla.Data;
using Molla.Models;
using Molla.Services.Interface;

namespace Molla.Services
{
    public class TeamService : ITeamService
    {
        private readonly AppDbContext _context;

        public TeamService(AppDbContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<Team>> GetAllAsync()
        {
          return await _context.Teams.Where(m => !m.SoftDeleted).Include(m => m.Position).ToListAsync();
        }
    }
}
