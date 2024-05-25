using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary.Models
{
    public class Warehouse
    {
        [Key]
        public int WarehouseId { get; set;}
        [StringLength(300)]
        public string? Address { get; set;}
        public int Capacity { get; set;}
    }
}