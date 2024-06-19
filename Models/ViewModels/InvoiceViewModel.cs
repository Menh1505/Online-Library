namespace OnlineLibrary.Models.ViewModels
{
    public class InvoiceViewModel
    {
        public IEnumerable<Invoice> Invoices { get; set;}
        public IEnumerable<InvoiceDetail> InvoicesDetails { get; set;}
    }
}