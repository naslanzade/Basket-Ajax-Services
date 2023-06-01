using Molla.Models;

namespace Molla.Services.Interface
{
    public interface ICustomerInterface
    {
        Task<IEnumerable<Customer>> GetAllAsync();
    }
}
