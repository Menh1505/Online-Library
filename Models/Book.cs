namespace OnlineLibrary.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookPhoto { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public string BookGenre { get; set; }
        public DateTime? BookPublicationDate { get; set; }
        public string? BookPublisher {get; set; }
        public string BookDescription { get; set; }
        public decimal? BookPages { get; set; }
        public int? BookRating { get; set; }
        public string BookLanguage { get; set; }
        public int CategoryId { get; set; }
    }

}