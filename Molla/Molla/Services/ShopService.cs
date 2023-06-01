using Microsoft.EntityFrameworkCore;
using Molla.Data;
using Molla.Models;
using Molla.Services.Interface;

namespace Molla.Services
{
    public class ShopService : IShopService
    {
        private readonly AppDbContext _context;

        public ShopService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.Where(m => !m.SoftDeleted).Include(m => m.Images).Include(m => m.Category).ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoryAsync()
        {
            return await _context.Categories.Where(m => !m.SoftDeleted).Skip(1).Take(8).ToListAsync();
        }
    }
}
