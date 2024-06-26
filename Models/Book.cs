using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineLibrary.Models
{
    [PrimaryKey("BookId")]
    public class Book
    {
        public int BookId { get; set; }
        [StringLength(300)]
        public string? BookPhoto { get; set; }
        [Required]
        [StringLength(150)]
        public string? BookISBN { get; set; }
        [Required]
        [StringLength(150)]
        public string? BookName { get; set; }
        [StringLength(150)]
        public string? BookAuthor { get; set; }
        [DataType(DataType.Date)]
        public DateTime? BookPublicationDate { get; set; }
        public string? BookPublisher { get; set; }
        [StringLength(30000)]
        public string? BookDescription { get; set; }
        public int? BookPages { get; set; }
        [Range(0, 5, ErrorMessage = "Value must be in 0 to 5")]
        public int? BookRating { get; set; }
        [StringLength(30)]
        public string? BookLanguage { get; set; }
        [Required]
        public bool Featured { get; set; }
        [Required]
        public bool JustArrived { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal SellPrice { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal RentalPrice { get; set; }
        public bool IsDiscount { get; set; }
        [Column(TypeName = "decimal(2,2)")]
        public decimal? DiscountAmount { get; set; }
    }
}