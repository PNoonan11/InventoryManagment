using InventoryManagement.Server.Services.Customers;
using InventoryManagement.Shared.Models.Customers;
using InventoryManagement.Shared.Models.Sales;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;
       
        public CustomerController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }
        [HttpGet]
        public async Task<List<CustomerListItem>> Index()
        {

            var customers = await _customerServices.GetAllCustomersAsync();
            return customers.ToList();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Customer(int id)
        {

            var customer = await _customerServices.GetCustomerByIdAsync(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreate model)
        {
            if (model == null) return BadRequest();
            
            bool wasSuccessful = await _customerServices.CreateCustomerAsync(model);
            if (wasSuccessful) return Ok();
            else return UnprocessableEntity();
        }
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, CustomerEdit model)
        {
            
            if (model == null || !ModelState.IsValid) return BadRequest();
            if (model.Id != id) return BadRequest();
            bool wasSuccessful = await _customerServices.UpdateCustomerAsync(model);
            if (wasSuccessful) return Ok();
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            
            var customer = await _customerServices.GetCustomerByIdAsync(id);
            if (customer == null) return NotFound();
            bool wasSuccessful = await _customerServices.DeleteCustomerAsync(id);
            if (!wasSuccessful) return BadRequest();
            return Ok();
        }





    }
}
