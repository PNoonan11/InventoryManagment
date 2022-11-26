using InventoryManagement.Shared.Models.Products;

namespace InventoryManagement.Server.Services.Products
{
    public interface IProductServices
    {

        Task<bool> CreateProductAsync(ProductCreate model);
        Task<IEnumerable<ProductListItem>> GetProductsAsync();
        Task<ProductDetail> GetProductByIdAsync(int productId);
        Task<bool> UpdateProductAsync(ProductEdit model);
        Task<bool> DeleteProductAsync(int productId);
        void SetUserId(string userId);
    }


}
