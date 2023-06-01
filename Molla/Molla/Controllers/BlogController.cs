using Microsoft.AspNetCore.Mvc;
using Molla.Models;
using Molla.Services;
using Molla.Services.Interface;
using Molla.ViewModels;

namespace Molla.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IPopulaBlogService _popularBlogService;


        public BlogController(IBlogService blogService,IPopulaBlogService populaBlogService)
        {
            _blogService = blogService;
            _popularBlogService = populaBlogService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Blog> blogs = await _blogService.GetAllAsync();
            IEnumerable<PopulaBlog> popularBlogs= await _popularBlogService.GetAllAsync();

            BlogVM model = new()
            {
                Blogs = blogs,
                PopulaBlogs = popularBlogs

            };

            return View(model);
        }
    }
}
