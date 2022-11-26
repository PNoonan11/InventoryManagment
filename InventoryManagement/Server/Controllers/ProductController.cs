using InventoryManagement.Shared.Models.Products;
using InventoryManagement.Server.Services.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InventoryManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;
        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
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
            _productServices.SetUserId(userId);
            return true;
        }
        [HttpGet]
        public async Task<List<ProductListItem>> Index()
        {
            
            var products = await _productServices.GetProductsAsync();
            return products.ToList();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Product(int id)
        {
            
            var product = await _productServices.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreate model)
        {
            if (model == null) return BadRequest();
            //if (!SetUserIdInService()) return Unauthorized();
            bool wasSuccessful = await _productServices.CreateProductAsync(model);
                if (wasSuccessful) return Ok();
            else return UnprocessableEntity();
        }
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, ProductEdit model)
        {
            //if (!SetUserIdInService()) return Unauthorized();
            if (model == null || !ModelState.IsValid) return BadRequest();
            if (model.Id != id) return BadRequest();
            bool wasSuccessful = await _productServices.UpdateProductAsync(model);
            if (wasSuccessful) return Ok();
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           // if (!SetUserIdInService()) return Unauthorized();
            var product = await _productServices.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            bool wasSuccessful = await _productServices.DeleteProductAsync(id);
            if (!wasSuccessful) return BadRequest();
            return Ok();
        }


    } 
}
