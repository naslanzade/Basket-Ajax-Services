using Microsoft.EntityFrameworkCore;
using Molla.Data;
using Molla.Models;
using Molla.Services.Interface;

namespace Molla.Services
{
    public class SliderService : ISliderService
    {
        private readonly AppDbContext _context;

        public SliderService(AppDbContext context)
        {
            _context = context;

        }
        public async Task<Slider> GetAllAsync()
        {
           return await _context.Sliders.Where(m => !m.SoftDeleted).FirstOrDefaultAsync();
        }
    }
}
