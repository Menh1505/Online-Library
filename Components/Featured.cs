using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Data;
using OnlineLibrary.Models;

namespace OnlineLibrary.Components
{
    public class Featured : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public Featured(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            return View(_context.Books.Where(b=>b.Featured == true).ToList());
        }
    }
}