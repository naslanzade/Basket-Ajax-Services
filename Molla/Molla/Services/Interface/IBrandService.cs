using Molla.Models;

namespace Molla.Services.Interface
{
    public interface IBrandService
    {
        Task<IEnumerable<Brand>> GetAllAsync();
    }
}
