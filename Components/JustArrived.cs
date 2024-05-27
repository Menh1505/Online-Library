using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Data;
using OnlineLibrary.Models;
using OnlineLibrary.ViewModel;

namespace OnlineLibrary.Components
{
    public class JustArrived : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public JustArrived(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var model = from book in _context.Books
                        join price in _context.BookPrices on book.BookId equals price.BookId
                        join discount in _context.Discounts on price.DiscountId equals discount.DiscountId
                        select new BookViewModel
                        {
                            BookId = book.BookId,
                            BookPhoto = book.BookPhoto,
                            BookName = book.BookName,
                            BookAuthor = book.BookAuthor,
                            BookGenre = book.BookGenre,
                            BookPublicationDate = book.BookPublicationDate,
                            BookPublisher = book.BookPublisher,
                            BookDescription = book.BookDescription,
                            BookPages = book.BookPages,
                            BookRating = book.BookRating,
                            BookLanguage = book.BookLanguage,
                            Featured = book.Featured,
                            JustArrived = book.JustArrived,
                            Sell = price.Sell,
                            Rentall = price.Rentall,
                            IsDiscount = price.IsDiscount,
                            DiscountName = discount.DiscountName,   
                            DiscountAmount = discount.DiscountAmount
                        };
            return View(model.Where(b=>b.JustArrived == true).ToList());
        }
    }
}