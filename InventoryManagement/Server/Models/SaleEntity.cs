using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Server.Models
{
    public class SaleEntity
    {
        [Key]
        public int Id { get; set; }
        public string ProductSold { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantitySold { get; set; }
        [ForeignKey("Location")]
        public int LocationSoldFrom { get; set; }
        public virtual LocationEntity Location { get; set; }
        public DateTimeOffset DateOfSale { get; set; }
        [ForeignKey("Customer")]
        public int CustomerSoldTo { get; set; }
        public virtual CustomerEntity Customer { get; set; }
        [ForeignKey("SoldById")]
        public string SoldByUserId { get; set; }
        public virtual ApplicationUser SoldById { get; set; }
        public virtual ICollection<CustomerEntity> ListOfCustomers { get; set; }
    }
}
