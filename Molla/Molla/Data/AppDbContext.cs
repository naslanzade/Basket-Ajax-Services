using Microsoft.EntityFrameworkCore;
using Molla.Models;

namespace Molla.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opttion) : base(opttion)
        {

        }

      
        public DbSet<LittleInfo> LittleInfos { get; set; }
        public DbSet<InfoImage> InfoImages { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<BrandInfo> BrandInfos { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<CustomerHeading> CustomerHeadings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<PopulaBlog> PopulaBlogs { get; set;}
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<OtherProduct> OtherProducts { get; set; }
        public DbSet<Category> Categories { get; set; }        
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }






    }
}
