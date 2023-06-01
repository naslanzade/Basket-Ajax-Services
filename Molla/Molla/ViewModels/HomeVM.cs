using Molla.Models;

namespace Molla.ViewModels
{
    public class HomeVM
    {
        public Slider ? Slider { get; set; }
        public IEnumerable<OtherProduct> ? OtherProduct { get; set; }
        public IEnumerable<Brand> ? Brand { get; set; }        
        public IEnumerable <Product> ? Product { get; set;}
        public IEnumerable<Product>? Product1 { get; set; }
        public IEnumerable<Product>? Product2 { get; set; }
        public IEnumerable<Product> ? OtherCard { get; set; }
        public IEnumerable<Product> ? Accessories { get; set; }
        public IEnumerable<Product>? All { get; set; }
        public IEnumerable<Product>? Camera { get; set; }
        public IEnumerable<Product>? Computer { get; set; }
        public IEnumerable<Product>? Entertainment { get; set; }
        public IEnumerable<Category> ? Categories { get; set; }

        



    }
}
