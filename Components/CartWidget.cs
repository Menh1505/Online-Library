using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Data;
using OnlineLibrary.Infrastructure;
using OnlineLibrary.Models;

namespace OnlineLibrary.Components
{
    public class CartWidget : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public CartWidget(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            return View(HttpContext.Session.GetJson<Cart>("cart"));
        }
    }
}