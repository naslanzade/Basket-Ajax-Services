using Molla.Models;

namespace Molla.ViewModels
{
    public class BlogVM
    {
        public IEnumerable<Blog> ? Blogs { get; set; }
        public IEnumerable<PopulaBlog> ? PopulaBlogs { get; set; }
    }
}
