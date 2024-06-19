using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace OnlineLibrary.Models
{
    [PrimaryKey("Id", "InvoiceId")]
    public class Invoice 
    {
        [ForeignKey("InvoiceDetail")]
        public int InvoiceId { get; set;}
        public InvoiceDetail? invoiceDetail { get; set;}
        [ForeignKey("Users")]
        public string Id { get; set;}
        public IdentityUser? identityUser{ get; set; }
        public DateTime PaidDate { get; set;}
        
    }
}