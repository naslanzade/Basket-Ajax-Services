using Molla.Models;

namespace Molla.Services.Interface
{
    public interface IBlogService
    {
        Task<IEnumerable<Blog>> GetAllAsync();
    }
}
