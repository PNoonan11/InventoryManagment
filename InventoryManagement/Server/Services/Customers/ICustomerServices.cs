using InventoryManagement.Shared.Models.Customers;

namespace InventoryManagement.Server.Services.Customers
{
    public interface ICustomerServices
    {
        Task<bool> CreateCustomerAsync(CustomerCreate model);
        Task<IEnumerable<CustomerListItem>> GetAllCustomersAsync();
        Task<CustomerDetail> GetCustomerByIdAsync(int customerId);
        Task<bool> UpdateCustomerAsync(CustomerEdit model);
        Task<bool> DeleteCustomerAsync(int customerId);


    }
}