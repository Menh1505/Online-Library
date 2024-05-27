using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [StringLength(100)]
        public string? CategoryName { get; set; }
        [StringLength(300)]
        public string? CategoryPhoto { get; set; }
    }
}