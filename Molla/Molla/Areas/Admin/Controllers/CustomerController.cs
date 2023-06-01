using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla.Areas.Admin.ViewModels.Blog;
using Molla.Areas.Admin.ViewModels.Customer;
using Molla.Data;
using Molla.Models;

namespace Molla.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerController : Controller
    {
        private readonly AppDbContext _context;

        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<CustomerVM> list = new();
            List<Customer> customers = await _context.Customers.Where(m => !m.SoftDeleted).ToListAsync();
            foreach (Customer item in customers)
            {
                CustomerVM model = new()
                {
                    Id = item.Id,
                    Image=item.Image,
                    FullName=item.FullName,
                };

                list.Add(model);
            }
            return View(list);
        }



        [HttpGet]

        public async Task<IActionResult> Detail(int? id)
        {

            if (id is null) return BadRequest();

            Customer dbCustomer = await _context.Customers.FirstOrDefaultAsync(m => m.Id == id);

            if (dbCustomer is null) return NotFound();

            CustomerDetailVM model = new()
            {

                Image = dbCustomer.Image,
                FullName = dbCustomer.FullName,
                Position = dbCustomer.Position,
                Description = dbCustomer.Description,
                CreatedDate = dbCustomer.CreatedDate.ToString("MMMM dd, yyyy"),
            };
            return View(model);
        }
    }
}
