using Domain;
using E_Commerce_Shop.Contracts.V1;
using E_Commerce_Shop.Contracts.V1.DTO_requests.CREATE;
using E_Commerce_Shop.Contracts.V1.DTO_requests.UPDATE;
using E_Commerce_Shop.Contracts.V1.DTO_responses;
using Logic.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Shop.Controllers.V1
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet(ApiRoutes.Products.GetAllProducts)]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _productService.GetProductsAsync());
        }

        [HttpGet(ApiRoutes.Products.GetProductByID)]
        public async Task<IActionResult> GetProductById([FromRoute] int productId)
        {
            var product = await _productService.GetProductByIdAsync(productId);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost(ApiRoutes.Products.AddProduct)]
        public async Task<IActionResult> AddProduct([FromBody] CreateProductRequestDTO request)
        {
            await _productService.CreateProductAsync(new Product()
            {
                Name = request.Name,
                Description = request.Description,
                CategoryId = request.CategoryId,
                Price = request.Price,
                AvailableItems = request.AvailableItems
            });

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Products.GetProductByID
                .Replace("{productId}", (await _productService.GetProductsAsync()).Last().Id.ToString());

            return Created(locationUri, new CreateProductResponseDTO() { Id = (await _productService.GetProductsAsync()).Last().Id });
        }

        [HttpPut(ApiRoutes.Products.UpdateProduct)]
        public async Task<IActionResult> UpdateProduct([FromRoute] int productId, [FromBody] UpdateProductRequestDTO request)
        {
            var product = new Product
            {
                Id = productId,
                Name = request.Name,
                Description = request.Description,
                CategoryId = request.CategoryId,
                Price = request.Price,
                AvailableItems = request.AvailableItems
            };

            var updated = await _productService.UpdateProductAsync(product);

            if (updated)
                return Ok(product);

            return NotFound();
        }

        [HttpDelete(ApiRoutes.Products.DeleteProduct)]
        public async Task<IActionResult> DeleteProduct([FromRoute] int productId)
        {
            var deleted = await _productService.DeleteProductAsync(productId);

            if (deleted)
                return NoContent();

            return NotFound();
        }
    }
}

