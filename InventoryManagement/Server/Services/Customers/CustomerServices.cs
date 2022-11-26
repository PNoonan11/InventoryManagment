using InventoryManagement.Server.Data;
using InventoryManagement.Server.Models;
using InventoryManagement.Shared.Models.Customers;
using InventoryManagement.Shared.Models.Locations;
using Microsoft.EntityFrameworkCore;


namespace InventoryManagement.Server.Services.Customers
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ApplicationDbContext _context;
        public CustomerServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateCustomerAsync(CustomerCreate model)
        {
            if (model == null) return false;
            var customerEntity = new CustomerEntity
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            };
            _context.Customers.Add(customerEntity);
            return await _context.SaveChangesAsync() == 1;
        }


        public async Task<IEnumerable<CustomerListItem>> GetAllCustomersAsync()
        {
            var customerQuery = _context.Customers.Select(entity => new CustomerListItem
            {
                Id = entity.Id,
                FullName = entity.FullName,
                Email = entity.Email
            });
            return await customerQuery.ToListAsync();
        }

        public async Task<CustomerDetail> GetCustomerByIdAsync(int customerId)
        {
            var customerById = await _context.Customers.FirstOrDefaultAsync(r => r.Id == customerId);
            if (customerById == null)
                return null;
            var detail = new CustomerDetail
            {
                Id = customerById.Id,
                FirstName = customerById.FirstName,
                LastName = customerById.LastName,
                Email = customerById.Email,
                
                

            };
            return detail;

        }
        

        public async Task<bool> UpdateCustomerAsync(CustomerEdit model)
        {
            if (model == null)
                return false;
            var customerToUpdate = await _context.Customers.FindAsync(model.Id);
            customerToUpdate.FirstName = model.FirstName;
            customerToUpdate.LastName = model.LastName;
            customerToUpdate.Email = model.Email;
            return await _context.SaveChangesAsync() == 1;

        }
        public async Task<bool> DeleteCustomerAsync(int customerId)
        {
            var customerToDelete = await _context.Customers.FindAsync(customerId);
            if (customerToDelete == null)
                return false;
            _context.Customers.Remove(customerToDelete);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}



