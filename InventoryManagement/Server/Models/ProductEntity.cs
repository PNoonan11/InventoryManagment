using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Server.Models
{
    public class ProductEntity
    {
        [Key]
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
        public DateTimeOffset? DateLastSold { get; set; }
        
        
        public virtual ICollection<ProductInLocations> ListOfProducts { get; set; }




    }
}
