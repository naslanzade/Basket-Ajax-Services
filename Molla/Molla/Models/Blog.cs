namespace Molla.Models
{
    public class Blog :BaseEntity
    {
        public string ? BlogImage { get; set; }
        public string ? Author { get; set; }
        public int CommentCount { get; set; }
        public string ? Title { get; set; }
        public string? TitleSecond { get; set; }
        public string ? Context { get; set; }
        public string ? Description { get; set; }

    }
}
