using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Data;

namespace MyApp.Namespace
{
    public class InvoiceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InvoiceController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View();
        }

    }
}
