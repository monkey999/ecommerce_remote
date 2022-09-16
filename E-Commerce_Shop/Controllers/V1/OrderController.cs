using Domain;
using E_Commerce_Shop.Contracts.V1;
using E_Commerce_Shop.Contracts.V1.DTO_requests;
using E_Commerce_Shop.Contracts.V1.DTO_requests.CREATE;
using E_Commerce_Shop.Contracts.V1.DTO_responses;
using Logic.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Shop.Controllers.V1
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
            
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet(ApiRoutes.Orders.GetAllOrders)]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok(await _orderService.GetOrdersAsync());
        }

        [HttpGet(ApiRoutes.Orders.GetOrderByID)]
        public async Task<IActionResult> GetOrderById([FromRoute] int orderId)
        {
            var order = await _orderService.GetOrderByIdAsync(orderId);

            if (order == null)
                return NotFound();

            return Ok(order);
        }

        [HttpPost(ApiRoutes.Orders.AddOrder)]
        public async Task<IActionResult> AddUser([FromBody] CreateOrderRequestDTO request)
        {
            await _orderService.CreateOrderAsync(new Order()
            {
                CartItemId = request.CartItemId,
                UserId = request.UserId,
                Address1 = request.Address1,
                Address2 = request.Address2,
                City = request.City,
                Country = request.Country,
                PostalCode = request.PostalCode,
                GiftWrap = request.GiftWrap,
                Dispatched = request.Dispatched
            });

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Orders.GetOrderByID
                .Replace("{orderId}", (await _orderService.GetOrdersAsync()).Last().Id.ToString());

            return Created(locationUri, new CreateOrderResponseDTO() { Id = (await _orderService.GetOrdersAsync()).Last().Id });
        }

        [HttpPut(ApiRoutes.Orders.UpdateOrder)]
        public async Task<IActionResult> UpdateUser([FromRoute] int orderId, [FromBody] UpdateOrderRequestDTO request)
        {
            var order = new Order
            {
                Id = orderId,
                CartItemId = request.CartItemId,
                UserId = request.UserId,
                Address1 = request.Address1,
                Address2 = request.Address2,
                City = request.City,
                Country = request.Country,
                PostalCode = request.PostalCode,
                GiftWrap = request.GiftWrap,
                Dispatched = request.Dispatched
            };

            var updated = await _orderService.UpdateOrderAsync(order);

            if (updated)
                return Ok(order);

            return NotFound();
        }

        [HttpDelete(ApiRoutes.Orders.DeleteOrder)]
        public async Task<IActionResult> DeleteUser([FromRoute] int orderId)
        {
            var deleted = await _orderService.DeleteOrderAsync(orderId);

            if (deleted)
                return NoContent();

            return NotFound();
        }
    }
}
