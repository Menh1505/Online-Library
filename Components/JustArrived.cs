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
            return View(_context.Books.Where(b=>b.JustArrived == true).ToList());
        }
    }
}