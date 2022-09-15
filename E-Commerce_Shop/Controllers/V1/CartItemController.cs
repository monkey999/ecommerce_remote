using Domain;
using E_Commerce_Shop.Contracts.V1;
using E_Commerce_Shop.Contracts.V1.DTO_requests;
using E_Commerce_Shop.Contracts.V1.DTO_responses;
using Logic.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Shop.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemService _cartItemService;

        public CartItemController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        [HttpGet(ApiRoutes.CartItems.GetAllCartItems)]
        public async Task<IActionResult> GetAllCartItems()
        {
            return Ok(await _cartItemService.GetAllCartItemsAsync());
        }

        [HttpGet(ApiRoutes.CartItems.GetCartItemById)]
        public async Task<IActionResult> GetCartItemById([FromRoute] int cartItemId)
        {
            var cartItem = await _cartItemService.GetCartItemByIdAsync(cartItemId);

            if (cartItem == null)
                return NotFound();

            return Ok(cartItem);
        }

        [HttpPost(ApiRoutes.CartItems.AddCartItem)]
        public async Task<IActionResult> AddCartItem([FromBody] CreateCartItemRequestDTO request)
        {
            await _cartItemService.CreateCartItem(new CartItem()
            {
                CartId = request.CartId,
                Quantity = request.Quantity,
                ProductId = request.ProductId,
                DateCreated = DateTime.Now,
                BoughtStatus = request.BoughtStatus
            });

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.CartItems.GetCartItemById.Replace("{cartItemId}",
                (await _cartItemService.GetAllCartItemsAsync()).Last().Id.ToString());

            return Created(locationUri, new CreateCartItemResponseDTO() { Id = (await _cartItemService.GetAllCartItemsAsync()).Last().Id });
        }

        [HttpDelete(ApiRoutes.CartItems.DeleteCartItem)]
        public async Task<IActionResult> DeleteCartItem([FromRoute] int cartItemId)
        {
            var deleted = await _cartItemService.DeleteCartItemAsync(cartItemId);

            if (deleted)
                return NoContent();

            return NotFound();
        }

        [HttpPut(ApiRoutes.CartItems.UpdateCartItem)]
        public async Task<IActionResult> UpdateCartItem([FromRoute] int cartItemId, [FromBody] UpdateCartitemRequestDTO request)
        {
            var cartItem = new CartItem()
            {
                Id = cartItemId,
                CartId = request.CartId,
                Quantity = request.Quantity,
                ProductId = request.ProductId,
                DateCreated = DateTime.Now,
                BoughtStatus = request.BoughtStatus
            };

            var updated = await _cartItemService.UpdateCartItemAsync(cartItem);

            if (updated)
                return Ok(cartItem);

            return NotFound();
        }
    }
}
