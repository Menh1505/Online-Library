using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace OnlineLibrary.Models
{
    [PrimaryKey("InvoiceId")]
    public class Invoice 
    {
        public string InvoiceId { get; set;}
        [ForeignKey("Users")]
        public string Id { get; set;}
        public IdentityUser? identityUser{ get; set; }
        public DateTime PaidDate { get; set;}
        public decimal TotalValues { get; set; }
    }
}