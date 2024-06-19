using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
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
            return View("Cart", HttpContext.Session.GetJson<Cart>("cart") ?? new Cart());
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

        [Authorize]
        public async Task<IActionResult> CheckOut()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            string value = claims.Value.ToString();

            Invoice invoice = new Invoice();
            invoice.Id = value;
            invoice.PaidDate = DateTime.Now;
            string invoiceId = value.Substring(3) + DateTime.Now.ToString("ddMMYYYYHHmmss");
            invoice.InvoiceId = invoiceId;

            _context.Invoices.Add(invoice);

            Cart = HttpContext.Session.GetJson<Cart>("cart");
            foreach(var cart in Cart.Lines)
            {
                _context.InvoiceDetails.Add(new InvoiceDetail{
                    InvoiceId = invoiceId,
                    BookId = cart.Book.BookId,
                    Quantity = cart.Quantity
                });
            }
            Cart.Clear();
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Books", 1);
        }
    }
}
