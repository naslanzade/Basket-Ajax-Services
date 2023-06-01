using Microsoft.EntityFrameworkCore;
using Molla.Data;
using Molla.Models;
using Molla.Services.Interface;

namespace Molla.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAccessoriesAsync()
        {
            return await _context.Products.Where(m => !m.SoftDeleted).Include(m => m.Images).Include(m => m.Category).Take(3).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.Where(m => !m.SoftDeleted).Include(m => m.Images).Include(m => m.Category).Take(6).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByFeautureAsync()
        {
            return await _context.Products.Where(m=>!m.SoftDeleted).Include(m=>m.Images).Include(m=>m.Category).Take(5).ToListAsync();
        }

   

        public async Task<IEnumerable<Product>> GetByRateAsync()
        {
            return await _context.Products.Where(m => !m.SoftDeleted).Include(m => m.Images).Include(m => m.Category).Take(6).OrderByDescending(m=>m.Rate).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetBySaleAsync()
        {
            return await _context.Products.Where(m => !m.SoftDeleted).Include(m => m.Images).Include(m => m.Category).Take(6).OrderByDescending(m => m.TopSale).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetCamerasAsync()
        {
            return await _context.Products.Where(m => !m.SoftDeleted).Include(m => m.Images).Include(m => m.Category).Skip(2).Take(2).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetComputersAsync()
        {
            return await _context.Products.Where(m => !m.SoftDeleted).Include(m => m.Images).Include(m => m.Category).Skip(4).Take(1).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetEntertainmentAsync()
        {
            return await _context.Products.Where(m => !m.SoftDeleted).Include(m => m.Images).Include(m => m.Category).Skip(4).Take(3).ToListAsync();
        }


    }
}
