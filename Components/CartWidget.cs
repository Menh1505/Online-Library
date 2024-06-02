using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Data;
using OnlineLibrary.Models;
using OnlineLibrary.ViewModel;

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
            return View(_context.Books.Where(b=>b.Featured == true).ToList());
        }
    }
}