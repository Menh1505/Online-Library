using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Data;
using OnlineLibrary.Data.Migrations;
using OnlineLibrary.Models;
using OnlineLibrary.Models.ViewModels;

namespace OnlineLibrary.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InvoiceController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(new InvoiceViewModel{
                Invoices = (IEnumerable<Invoice>)_context.Invoices.ToList(),
                InvoicesDetails = (IEnumerable<InvoiceDetail>)_context.InvoiceDetails.ToList(),
                IdentityUsers = (IEnumerable<IdentityUser>)_context.Users.ToList()
            });
        }
    }
}
