using Molla.Models;

namespace Molla.Services.Interface
{
    public interface IShopService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<IEnumerable<Category>> GetCategoryAsync();
    }
}
