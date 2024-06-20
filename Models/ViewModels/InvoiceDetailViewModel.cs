using Microsoft.AspNetCore.Identity;

namespace OnlineLibrary.Models.ViewModels
{
    public class InvoiceDetailViewModel
    {
        public Invoice Invoice { get; set;}
        public IEnumerable<InvoiceDetail> InvoicesDetails { get; set;}
        public IdentityUser IdentityUsers{ get; set;}
    }
}