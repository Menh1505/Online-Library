using Microsoft.AspNetCore.Identity;

namespace OnlineLibrary.Models.ViewModels
{
    public class InvoiceViewModel
    {
        public IEnumerable<Invoice> Invoices { get; set;}
        public IEnumerable<InvoiceDetail> InvoicesDetails { get; set;}
        public IEnumerable<IdentityUser> IdentityUsers{ get; set;}
    }
}