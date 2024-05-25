using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineLibrary.Models
{
    [PrimaryKey("WarehouseId", "BookId")]
    public class Inventory
    {
        [ForeignKey("Warehouse")]
        public int WarehouseId { get; set;}
        public Warehouse Warehouse { get; set;}
        [ForeignKey("Book")]
        public int BookId { get; set;}
        public Book Book { get; set;}
        [DataType(DataType.Date)]
        public DateTime? ImportDate { get; set;}
        public int TotalQuantity { get; set;}
        public int LendingQuantity { get; set;}
    }
}