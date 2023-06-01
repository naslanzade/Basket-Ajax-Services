using Microsoft.EntityFrameworkCore;
using Molla.Data;
using Molla.Models;
using Molla.Services.Interface;

namespace Molla.Services
{
    public class CustomerService : ICustomerInterface
    {
        private readonly AppDbContext _context;

        public CustomerService(AppDbContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.Where(m => !m.SoftDeleted).ToListAsync();
        }
    }
}
