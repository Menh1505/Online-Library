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
            IEnumerable<Invoice> invoices = (IEnumerable<Invoice>)_context.Invoices.ToList();
            IEnumerable<InvoiceDetail> invoiceDetails = (IEnumerable<InvoiceDetail>)_context.InvoiceDetails.ToList();
            return View(new InvoiceViewModel{
                Invoices = invoices,
                InvoicesDetails = invoiceDetails
            });
        }
    }
}
