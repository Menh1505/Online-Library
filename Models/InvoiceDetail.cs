using Microsoft.EntityFrameworkCore;

namespace OnlineLibrary.Models
{
    [PrimaryKey("InvoiceId")]
    public class InvoiceDetail
    {
        public int InvoiceId { get; set;}
        public Book? Books{ get; set; }
        public int Quantity {get; set;}
        public DateTime PaidDate { get; set;}
    }
}