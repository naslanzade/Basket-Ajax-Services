using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla.Data;
using Molla.Models;
using Molla.Services.Interface;
using Molla.ViewModels;

namespace Molla.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IBrandService _brandService;
        private readonly ICustomerInterface _customerInterface;
        private readonly ITeamService _teamService;

        public AboutController(AppDbContext context,IBrandService brandService, ICustomerInterface customerInterface,ITeamService teamService)
        {
            _context = context;
            _brandService = brandService;
            _customerInterface = customerInterface;
            _teamService = teamService;
        }


        public async Task< IActionResult> Index()
        {
            IEnumerable<Brand> brands = await _brandService.GetAllAsync();
            BrandInfo brandInfo = await _context.BrandInfos.Where(m => !m.SoftDeleted).FirstOrDefaultAsync();
            IEnumerable<Customer> customers=await _customerInterface.GetAllAsync();
            CustomerHeading customerHeading= await _context.CustomerHeadings.Where(m => !m.SoftDeleted).FirstOrDefaultAsync();
            InfoImage infoImage= await _context.InfoImages.Where(m => !m.SoftDeleted).FirstOrDefaultAsync();
            LittleInfo littleInfo = await _context.LittleInfos.Where(m => !m.SoftDeleted).FirstOrDefaultAsync();
            IEnumerable<Team> teams=await _teamService.GetAllAsync();

            AboutVM model = new()
            {
                Brand=brands,
                BrandInfo=brandInfo,
                Customer=customers,
                CustomerHeading=customerHeading,
                InfoImage=infoImage,
                LittleInfo=littleInfo,
                Team=teams

            };


            return View(model);
        }
    }
}
