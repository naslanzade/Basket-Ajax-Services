using Molla.Models;

namespace Molla.Services.Interface
{
    public interface IOtherProductService
    {
        Task<IEnumerable<OtherProduct>> GetAllAsync();
    }
}
