using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla.Data;
using Molla.Models;
using Molla.Services.Interface;
using Molla.ViewModels;

namespace Molla.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopService _shopService;


        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
           
            
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = await _shopService.GetAllAsync();   
            IEnumerable<Category> categories=await _shopService.GetCategoryAsync();

            ShopVM model = new()
            {
                Product=products,
                Categories=categories

            };

            return View(model);
        }
    }
}
