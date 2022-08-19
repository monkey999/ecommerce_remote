using Domain;
using E_Commerce_Shop.DTO;
using Logic.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace E_Commerce_Shop.Controllers
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

        [HttpPost]
        public async Task<IActionResult> AddCartItem([FromBody] CreateCartItemDTO dto)
        {
            _cartItemService.CreateCartItem(new CartItem()
            {
                CartId = dto.CartId,
                Quantity = dto.Quantity,
                ProductId = dto.ProductId,
                DateCreated = DateTime.Now,
                BoughtStatus = dto.BoughtStatus
            });

            return Ok(await _cartItemService.

        }


        [HttpGet("GetAllCartItems")]
        public async Task<IActionResult> GetAllCartItems()
        {
            return Ok(await _cartItemService.GetAllCartItemsAsync());
        }


        [HttpGet("GetByIdCartItems{id}")]
        public async Task<IActionResult> GetByIdCartItems(int id)
        {
            return Ok(await _cartItemService.GetByIdCartItemsAsync(id));
        }

        [HttpGet("GetCartItemsByConditionAsync")]
        public async Task<IActionResult> GetCartItemsByConditionAsync(Expression<Func<CartItem, bool>> expression)
        {

        }

        // PUT api/<CartItemController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{

        //}


        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCartItem(int id)
        //{
        //    var item = await _cartItemService.GetbyId(id);

        //    if (item == null) return BadRequest();


        //}
    }
}
