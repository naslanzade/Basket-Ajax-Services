namespace Molla.Models
{
    public class Customer : BaseEntity
    {
        public string? Image { get; set; }
        public string? Description { get; set; }
        public string? FullName { get; set; }
        public string? Position { get; set; }
    }
}
