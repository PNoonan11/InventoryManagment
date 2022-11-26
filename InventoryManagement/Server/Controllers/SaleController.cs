using InventoryManagement.Server.Services.Sales;
using InventoryManagement.Shared.Models.Products;
using InventoryManagement.Shared.Models.Sales;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InventoryManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleServices _saleServices;
        public SaleController(ISaleServices saleServices)
        {
            _saleServices = saleServices;
        }
        [HttpGet]
        public async Task<List<SaleListItem>> Index()
        {
            
            var sales = await _saleServices.GetAllSalesAsync();
            return sales.ToList();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Sale(int id)
        {
            
            var sale = await _saleServices.GetSaleByIdAsync(id);
            if (sale == null) return NotFound();
            return Ok(sale);
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaleCreate model)
        {
            if (model == null) return BadRequest();
            if (!SetUserIdInService()) return Unauthorized();

            bool wasSuccessful = await _saleServices.CreateSaleAsync(model);
            if (wasSuccessful) return Ok();
            else return UnprocessableEntity();
        }
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, SaleEdit model)
        {
            if (!SetUserIdInService()) return Unauthorized();
            if (model == null || !ModelState.IsValid) return BadRequest();
            if (model.Id != id) return BadRequest();
            bool wasSuccessful = await _saleServices.UpdateSaleAsync(model);
            if (wasSuccessful) return Ok();
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!SetUserIdInService()) return Unauthorized();
            var product = await _saleServices.GetSaleByIdAsync(id);
            if (product == null) return NotFound();
            bool wasSuccessful = await _saleServices.DeleteSaleAsync(id);
            if (!wasSuccessful) return BadRequest();
            return Ok();
        }

        private string GetUserId()
        {
            string userIdClaim = User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;
            
            if (userIdClaim == null) return null;
            return userIdClaim;
        }
        private bool SetUserIdInService()
        {
            var userId = GetUserId();
            if (userId == null) return false;
            _saleServices.SetUserId(userId);
            return true;
        }


    }
}

