namespace MyLibrary.Server.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public int Category { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int PublicationYear { get; set; }
        public string Genre { get; set; } = string.Empty;
        public string Edition { get; set; } = string.Empty;
    }
}
