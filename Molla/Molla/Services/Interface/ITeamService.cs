using Molla.Models;

namespace Molla.Services.Interface
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> GetAllAsync();
    }
}
