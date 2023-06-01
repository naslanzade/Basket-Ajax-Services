using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla.Data;
using Molla.Models;
using Molla.Services.Interface;
using Molla.ViewModels;
using System.Diagnostics;

namespace Molla.Controllers
{
    public class HomeController : Controller
    {

        private readonly ISliderService _sliderService;
        private readonly IOtherProductService _otherProductService;
        private readonly IBrandService _brandService;
        private readonly IProductService _productService;
        private readonly AppDbContext _context;

        public HomeController(ISliderService sliderService,IOtherProductService otherProductService, IBrandService brandService,IProductService productService, AppDbContext context)
        {
            _sliderService = sliderService;
            _otherProductService = otherProductService;
            _brandService = brandService;
            _productService = productService;
            _context = context;
        }



        public async Task< IActionResult> Index()
        {

            Slider sliders = await _sliderService.GetAllAsync();
            IEnumerable<OtherProduct> otherProducts = await _otherProductService.GetAllAsync();
            IEnumerable<Brand> brands = await _brandService.GetAllAsync();
            IEnumerable<Product> products = await _productService.GetByFeautureAsync();
            IEnumerable<Product> products1 = await _productService.GetByRateAsync();
            IEnumerable<Product> products2=await _productService.GetBySaleAsync();
            IEnumerable<Product> otherCard = await _context.Products.Where(m => !m.SoftDeleted).Include(m => m.Images).Include(m => m.Category).Skip(8).Take(2).ToListAsync();
            IEnumerable<Product> accessorieses = await _productService.GetAccessoriesAsync();
            IEnumerable<Product> alls = await _productService.GetAllAsync();
            IEnumerable<Product> computers = await _productService.GetComputersAsync();
            IEnumerable<Product> cameras = await _productService.GetCamerasAsync();
            IEnumerable<Product> entertainments = await _productService.GetEntertainmentAsync();
            IEnumerable<Category> categories = await _context.Categories.Where(m => !m.SoftDeleted).ToListAsync();
           



            HomeVM model = new()
            {
                Slider=sliders,
                OtherProduct=otherProducts,
                Brand=brands,
                Product=products,
                Product1=products1,
                Product2=products2,
                OtherCard=otherCard,
                Accessories=accessorieses,
                All=alls,
                Computer=computers,
                Camera=cameras,
                Entertainment=entertainments,
                Categories=categories
                
            };

            return View(model);
        }

      
    }
}