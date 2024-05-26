namespace OnlineLibrary.ViewModel
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public string? BookPhoto { get; set; }
        public string? BookName { get; set; }
        public string? BookAuthor { get; set; }
        public string? BookGenre { get; set; }
        public DateTime? BookPublicationDate { get; set; }
        public string? BookPublisher { get; set; }
        public string? BookDescription { get; set; }
        public int? BookPages { get; set; }
        public int? BookRating { get; set; }
        public string? BookLanguage { get; set; }
        public bool Featured { get; set; }
        public bool JustArrived {get; set; }
        public decimal? Sell { get; set;}
        public decimal? Rentall { get; set;}
        public bool IsDiscount { get; set;}
        public string? DiscountName { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}