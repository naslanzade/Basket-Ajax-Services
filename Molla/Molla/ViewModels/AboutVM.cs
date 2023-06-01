using Molla.Models;

namespace Molla.ViewModels
{
    public class AboutVM
    {
        public IEnumerable<Brand> Brand { get; set; }
        public BrandInfo BrandInfo { get; set; }
        public IEnumerable<Customer> Customer { get; set; }
        public CustomerHeading CustomerHeading { get; set; }
        public InfoImage InfoImage { get; set; }
        public LittleInfo LittleInfo { get; set; }  
        public IEnumerable<Team> Team { get; set; }

    }
}
