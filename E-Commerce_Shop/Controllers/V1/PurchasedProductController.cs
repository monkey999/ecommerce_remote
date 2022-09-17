using Domain;
using E_Commerce_Shop.Contracts.V1;
using E_Commerce_Shop.Contracts.V1.DTO_requests.CREATE;
using E_Commerce_Shop.Contracts.V1.DTO_requests.UPDATE;
using E_Commerce_Shop.Contracts.V1.DTO_responses;
using Logic.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Shop.Controllers.V1
{
    [Route("api/purchasedProduct")]
    [ApiController]
    public class PurchasedProductController : ControllerBase
    {
        private readonly IPurchasedProductService _purchasedProductService;

        public PurchasedProductController(IPurchasedProductService productService)
        {
            _purchasedProductService = productService;
        }

        [HttpGet(ApiRoutes.PurchasedProducts.GetAllPurchasedProducts)]
        public async Task<IActionResult> GetAllPurchasedProducts()
        {
            return Ok(await _purchasedProductService.GetPurchasedProductsAsync());
        }

        [HttpGet(ApiRoutes.PurchasedProducts.GetPurchasedProductByID)]
        public async Task<IActionResult> GetPurchasedProductById([FromRoute] int purchasedProductId)
        {
            var purchasedProduct = await _purchasedProductService.GetPurchasedProductByIdAsync(purchasedProductId);

            if (purchasedProduct == null)
                return NotFound();

            return Ok(purchasedProduct);
        }

        [HttpPost(ApiRoutes.PurchasedProducts.AddPurchasedProduct)]
        public async Task<IActionResult> AddPurchasedProduct([FromBody] CreatePurchasedProductRequestDTO request)
        {
            await _purchasedProductService.CreatePurchasedProductAsync(new PurchasedProduct()
            {
                CartItemId = request.CartItemId,
                DatePurchased = DateTime.Now
            });

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.PurchasedProducts.GetPurchasedProductByID
                .Replace("{purchasedProductId}", (await _purchasedProductService.GetPurchasedProductsAsync()).Last().Id.ToString());

            return Created(locationUri, new CreatePurchasedProductResponseDTO() { Id = (await _purchasedProductService
                .GetPurchasedProductsAsync()).Last().Id });
        }

        [HttpPut(ApiRoutes.Users.UpdateUser)]
        public async Task<IActionResult> UpdatePurchasedProduct([FromRoute] int purchasedProductId, [FromBody] UpdatePurchasedProductRequestDTO request)
        {
            var purchasedProduct = new PurchasedProduct
            {
                Id = purchasedProductId,
                CartItemId = request.CartItemId,
                DatePurchased = DateTime.Now
            };

            var updated = await _purchasedProductService.UpdatePurchasedProductAsync(purchasedProduct);

            if (updated)
                return Ok(purchasedProduct);

            return NotFound();
        }

        [HttpDelete(ApiRoutes.PurchasedProducts.DeletePurchasedProduct)]
        public async Task<IActionResult> DeletePurchasedProduct([FromRoute] int purchasedProductId)
        {
            var deleted = await _purchasedProductService.DeletePurchasedProductAsync(purchasedProductId);

            if (deleted)
                return NoContent();

            return NotFound();
        }
    }
}
