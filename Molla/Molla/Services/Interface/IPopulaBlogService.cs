using Molla.Models;

namespace Molla.Services.Interface
{
    public interface IPopulaBlogService
    {
        Task<IEnumerable<PopulaBlog>> GetAllAsync();
    }
}
