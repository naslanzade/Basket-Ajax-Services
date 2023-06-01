using Microsoft.EntityFrameworkCore;
using Molla.Data;
using Molla.Models;
using Molla.Services.Interface;

namespace Molla.Services
{
    public class BlogService : IBlogService
    {

        private readonly AppDbContext _context;

        public BlogService(AppDbContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<Blog>> GetAllAsync()
        {
            return await _context.Blogs.Where(m => !m.SoftDeleted).ToListAsync();
        }
    }
}
