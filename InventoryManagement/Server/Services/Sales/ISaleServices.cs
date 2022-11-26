using InventoryManagement.Shared.Models.Customers;
using InventoryManagement.Shared.Models.Sales;

namespace InventoryManagement.Server.Services.Sales
{
    public interface ISaleServices
    {
        Task<bool> CreateSaleAsync(SaleCreate model);
        Task<IEnumerable<SaleListItem>> GetAllSalesAsync();
        Task<SaleDetail> GetSaleByIdAsync(int saleId);
        Task<bool> UpdateSaleAsync(SaleEdit model);
        Task<bool> DeleteSaleAsync(int saleId);
        void SetUserId(string userId);
    }
}
