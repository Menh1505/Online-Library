using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineLibrary.Models
{
    public class BookPrice
    {
        [Key]
        public int BookId { get; set;}
        public Book Book { get; set;}
        [Column(TypeName = "decimal(8,2)")]
        public decimal? Sell { get; set;}
        [Column(TypeName = "decimal(8,2)")]
        public decimal? Rentall { get; set;}
        public bool IsDiscount { get; set;}
        [ForeignKey("Discount")]
        public int DiscountId {get; set;}
        public Discount Discount { get; set;}
    }
}