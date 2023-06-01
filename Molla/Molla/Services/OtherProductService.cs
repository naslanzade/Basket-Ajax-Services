using Microsoft.EntityFrameworkCore;
using Molla.Data;
using Molla.Models;
using Molla.Services.Interface;

namespace Molla.Services
{
    public class OtherProductService : IOtherProductService
    {
        private readonly AppDbContext _context;

        public OtherProductService(AppDbContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<OtherProduct>> GetAllAsync()
        {
            return await _context.OtherProducts.Where(m => !m.SoftDeleted).ToListAsync();
        }
    }
}
