using OnlineLibrary.Data;

namespace OnlineLibrary.Models.ViewModels
{
    public class BookListViewModel
    {
        public IEnumerable<Book> Books { get; set;} = Enumerable.Empty<Book>();
        public PagingInfo pagingInfo { get; set;} = new PagingInfo();
        public IEnumerable<Category> categories{ get; set;} = Enumerable.Empty<Category>();
        public IEnumerable<BookCategory> bookCategories { get; set;} = Enumerable.Empty<BookCategory>();
    }
}