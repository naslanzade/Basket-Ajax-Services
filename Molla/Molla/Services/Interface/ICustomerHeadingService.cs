using Molla.Models;

namespace Molla.Services.Interface
{
    public interface ICustomerHeadingService
    {
        Task<IEnumerable<CustomerHeading>> GetAllAsync();
    }
}
