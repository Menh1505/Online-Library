using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineLibrary.Models
{
    [PrimaryKey("InvoiceId", "BookId")]
    public class InvoiceDetail
    {
        [ForeignKey("Invoice")]
        public string InvoiceId { get; set;}
        public Invoice? invoices { get; set;}
        [ForeignKey("Book")]
        public int BookId { get; set;}
        public Book? Books{ get; set; }
        public int Quantity {get; set;}
    }
}