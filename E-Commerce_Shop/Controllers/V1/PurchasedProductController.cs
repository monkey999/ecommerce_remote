using E_Commerce_Shop.Contracts.V1.DTO_requests.CREATE;
using E_Commerce_Shop.Contracts.V1.DTO_responses;
using Logic.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;



namespace E_Commerce_Shop.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasedProductController : ControllerBase
    {
        private readonly IPurchasedProductService _purchasedProductService;

        public PurchasedProductController(IPurchasedProductService productService)
        {
            _purchasedProductService = productService;
        }

        // GET: api/<PurchasedProductController>
        [HttpGet]
        public IEnumerable<Domain.PurchasedProduct> GetAll() => _purchasedProductService.GetPurchasedProducts();


        // POST api/<PurchasedProductController>
        [HttpPost]
        public void AddPurchasedProduct([FromBody] CreatePurchasedProductRequestDTO dto)
        {
            _purchasedProductService.CreatePurchasedProduct(new Domain.PurchasedProduct()
            {
                CartItemId = dto.CartItemId,
                DatePurchased = DateTime.Now
            });

        }

        //// GET api/<PurchasedProductController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}



        //// PUT api/<PurchasedProductController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<PurchasedProductController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
