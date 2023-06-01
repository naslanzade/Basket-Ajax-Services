using Microsoft.EntityFrameworkCore;
using Molla.Data;
using Molla.Models;
using Molla.Services.Interface;

namespace Molla.Services
{
    public class PopularBlogService : IPopulaBlogService
    {
        private readonly AppDbContext _context;

        public PopularBlogService(AppDbContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<PopulaBlog>> GetAllAsync()
        {
           return await _context.PopulaBlogs.Where(m=>!m.SoftDeleted).ToListAsync();
        }
    }
}
