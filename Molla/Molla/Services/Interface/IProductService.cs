using Molla.Models;

namespace Molla.Services.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetByFeautureAsync();
        Task<IEnumerable<Product>> GetByRateAsync();
        Task<IEnumerable<Product>> GetBySaleAsync();
        Task<IEnumerable<Product>> GetAllAsync();
        Task<IEnumerable<Product>> GetAccessoriesAsync();
        Task<IEnumerable<Product>> GetCamerasAsync();
        Task<IEnumerable<Product>> GetComputersAsync();
        Task<IEnumerable<Product>> GetEntertainmentAsync();
     




    }
}
