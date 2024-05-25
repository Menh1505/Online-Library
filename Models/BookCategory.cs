using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineLibrary.Models
{
    [PrimaryKey("BookId", "CategoryId")]
    public class BookCategory
    {
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book? book { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set;}
    }
}