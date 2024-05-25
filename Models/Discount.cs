using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineLibrary.Models
{
    public class Discount
    {
        [Key]
        public int DiscountId { get; set; }
        [StringLength(100)]
        public string? DiscountName { get; set; }
        [Column(TypeName = "decimal(2,2)")]
        public decimal DiscountAmount { get; set; }
    }
}