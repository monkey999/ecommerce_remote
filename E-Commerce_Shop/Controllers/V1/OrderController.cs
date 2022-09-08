using E_Commerce_Shop.Contracts.V1.DTO_requests;
using E_Commerce_Shop.Contracts.V1.DTO_responses;
using Logic.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Commerce_Shop.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<Domain.Order> GetAll() => _orderService.GetOrders();

        // POST api/<OrderController>
        [HttpPost]
        public void AddOrder([FromBody] CreateOrderRequestDTO dto)
        {
            _orderService.CreateOrder(new Domain.Order()
            {
                CartItemId = dto.CartItemId,
                UserId = dto.UserId,
                Address1 = dto.Address1,
                Address2 = dto.Address2,
                City = dto.City,
                Country = dto.Country,
                PostalCode = dto.PostalCode,
                GiftWrap = dto.GiftWrap,
                Dispatched = dto.Dispatched
            });
        }

        // PUT api/<OrderController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<OrderController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}


        // GET api/<OrderController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}
    }
}
