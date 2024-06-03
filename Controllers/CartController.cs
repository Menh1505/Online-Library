using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Data;
using OnlineLibrary.Infrastructure;
using OnlineLibrary.Models;

namespace MyApp.Namespace
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }
        public Cart? Cart { get; set; }

        public IActionResult Index()
        {
            return View("Cart",  HttpContext.Session.GetJson<Cart>("cart") ?? new Cart());
        }
        public ActionResult AddToCart(int BookId)
        {
            Book? book = _context.Books.FirstOrDefault(b => b.BookId == BookId);
            if (book != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(book, 1);
                HttpContext.Session.SetJson("cart", Cart);
            }
            return View("Cart", Cart);
        }
        public ActionResult RemoveFromCart(int BookId)
        {
            Book? book = _context.Books.FirstOrDefault(b => b.BookId == BookId);
            if (book != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(book, -1);
                HttpContext.Session.SetJson("cart", Cart);
            }
            return View("Cart", Cart);
        }
        public ActionResult DeleteCart(int BookId)
        {
            Book? book = _context.Books.FirstOrDefault(b => b.BookId == BookId);
            if (book != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart");
                Cart.RemoveLine(book);
                HttpContext.Session.SetJson("cart", Cart);
            }
            return View("Cart", Cart);
        }
    }
}
