using Molla.Models;

namespace Molla.Areas.Admin.ViewModels.Team
{
    public class TeamDetailVM
    {
        public string? Image { get; set; }
        public string? FullName { get; set; }
        public string? Comment { get; set; }
        public int PositionId { get; set; }
        public Position? Position { get; set; }
        public string ? CreatedDate { get; set; }
    }
}
