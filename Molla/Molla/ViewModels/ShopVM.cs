using Molla.Models;

namespace Molla.ViewModels
{
    public class ShopVM
    {
        public IEnumerable<Category> ? Categories { get; set; }
        public IEnumerable<Product> ? Product { get; set; }
    }
}
