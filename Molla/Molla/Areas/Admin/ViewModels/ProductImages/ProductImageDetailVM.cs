using Molla.Models;

namespace Molla.Areas.Admin.ViewModels.ProductImages
{
    public class ProductImageDetailVM
    {
        public string? Image { get; set; }
        public int ProductId { get; set; }
        public Product ? Product { get; set; }
        public string ? CreatedDate { get; set; }
    }
}
