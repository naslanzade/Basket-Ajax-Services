using Microsoft.EntityFrameworkCore;
using Molla.Data;
using Molla.Models;
using Molla.Services.Interface;

namespace Molla.Services
{
    public class BrandService : IBrandService
    {
        private readonly AppDbContext _context;

        public BrandService(AppDbContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<Brand>> GetAllAsync()
        {
            return await _context.Brands.Where(m => !m.SoftDeleted).ToListAsync();
        }
    }
}
