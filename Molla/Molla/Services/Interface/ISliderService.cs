using Molla.Models;

namespace Molla.Services.Interface
{
    public interface ISliderService
    {
        Task<Slider> GetAllAsync();
    }
}
