using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Shared.Models.Products
{
    public class ProductCreate
    {
        public int Id { get; set; }
        
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public int StockNumber { get; set; }
        [Required]
        public int ProductLocation { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        public DateTimeOffset DateReceived { get; set; }
        
    }
}
