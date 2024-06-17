using OnlineLibrary.Data;

namespace OnlineLibrary.Models.ViewModels
{
    public class CreateBookViewModel
    {
        public Book book { get; set; }
        public BookCategory bookCategory{ get; set; }
        public Category category{ get; set; }
    }
}