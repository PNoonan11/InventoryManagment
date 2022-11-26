namespace InventoryManagement.Server.Models
{
    public class ProductsSold
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public ProductEntity Product { get; set; }
        public CustomerEntity Customer { get; set; }
    }
}
