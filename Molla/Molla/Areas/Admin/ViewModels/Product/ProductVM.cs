using Molla.Models;

namespace Molla.Areas.Admin.ViewModels.Products
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<ProductImage>? Images { get; set; }
    }
}
