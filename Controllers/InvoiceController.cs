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
            return View(new InvoiceViewModel
            {
                Invoices = (IEnumerable<Invoice>)_context.Invoices.ToList(),
                InvoicesDetails = (IEnumerable<InvoiceDetail>)_context.InvoiceDetails.ToList(),
                IdentityUsers = (IEnumerable<IdentityUser>)_context.Users.ToList()
            });
        }
        public IActionResult Detail(string invoiceId, string id)
        {
            var InvoicesDetails = _context.InvoiceDetails.Where(ivd => ivd.InvoiceId == invoiceId).ToList();
            foreach (var ivd in InvoicesDetails)
            {
                ivd.Books = _context.Books.FirstOrDefault(b => b.BookId == ivd.BookId);
            }

            return View(new InvoiceDetailViewModel
            {
                Invoice = _context.Invoices.FirstOrDefault(i => i.InvoiceId == invoiceId),
                InvoicesDetails = InvoicesDetails,
                IdentityUsers = _context.Users.FirstOrDefault(u => u.Id == id)
            });
        }
    }
}
