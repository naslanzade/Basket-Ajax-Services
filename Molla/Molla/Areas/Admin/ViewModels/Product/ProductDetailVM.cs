using Molla.Models;

namespace Molla.Areas.Admin.ViewModels.Products
{
    public class ProductDetailVM
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Detail { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<ProductImage>? Images { get; set; }
        public string? Stars { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
        public string ? CreatedDate { get; set; }
    }
}
