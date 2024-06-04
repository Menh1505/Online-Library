namespace OnlineLibrary.Models.ViewModel
{
    public class BookListViewModel
    {
        public IEnumerable<Book> Books { get; set;} = Enumerable.Empty<Book>();
        public PagingInfo pagingInfo { get; set;} = new PagingInfo();
    }
}