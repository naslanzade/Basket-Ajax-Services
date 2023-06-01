namespace Molla.Models
{
    public class Team : BaseEntity
    {
        public string? Image { get; set; }
        public string? FullName { get; set; }
        public string? Comment { get; set; }
        public int PositionId { get; set; }
        public Position? Position { get; set; }

    }
}
