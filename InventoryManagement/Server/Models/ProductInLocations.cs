namespace InventoryManagement.Server.Models
{
    public class ProductInLocations
    {
        public int ProductEntityId { get; set; }
        public int LocationEntityId { get; set; }
        public ProductEntity Product { get; set; }
        public LocationEntity Location { get; set; }
    }
}
