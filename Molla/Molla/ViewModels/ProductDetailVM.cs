﻿using Molla.Models;

namespace Molla.ViewModels
{
    public class ProductDetailVM
    {
        public int Id { get; set; }
        public string ? Name { get; set; }
        public string ? Description { get; set; }
        public decimal Price { get; set; }
        public List<ProductImage> ? Images { get; set; }
        public string ? Color { get; set; }
    }
}
