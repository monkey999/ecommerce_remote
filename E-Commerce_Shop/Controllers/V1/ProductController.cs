using E_Commerce_Shop.Contracts.V1.DTO_requests.CREATE;
using Logic.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Commerce_Shop.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Domain.Product>>> GetAll() => Ok(await _productService.GetProducts());

        // POST api/<ProductController>
        [HttpPost]
        public void AddProduct([FromBody] CreateProductRequestDTO dto)
        {
            _productService.CreateProduct(new Domain.Product()
            {
                Name = dto.Name,
                Description = dto.Description,
                CategoryId = dto.CategoryId,
                Price = dto.Price,
                AvailableItems = dto.AvailableItems
            });

        }

        // GET api/<ProductController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}



        // PUT api/<ProductController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ProductController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
