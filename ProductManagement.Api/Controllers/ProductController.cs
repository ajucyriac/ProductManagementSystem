using Microsoft.AspNetCore.Mvc;
using ProductManagement.Api.Common.Exceptions;
using ProductManagement.Api.Helpers;
using ProductManagement.Api.Model;
using ProductManagement.Api.Service.Interface;

namespace ProductManagement.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ProductDetails>>> GetAllProducts()
        {
            var result = await _productService.GetAllProduct();

            return result.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetails>> GetProductById(int id)
        {
            var result = await _productService.GetProductById(id);
            return result;
        }

        [HttpPost("upsert")]
        public async Task<ActionResult<ProductDetails>> UpsertProduct(ProductDetails product)
        {
            
             var result = await _productService.UpsertProduct(product);

            if (result == null)
                throw new AppException("Product not exist.");

            return result;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProduct(id);
            return Ok("Product successfully removed");
        }
    }
}
