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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        // POST api/<CategoryController>
        [HttpPost]
        public void AddCategory([FromBody] CreateCategoryRequestDTO dto)
        {
            _categoryService.CreateCategory(new Domain.Category()
            {
                Name = dto.Name,
                Description = dto.Description
            });
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<Domain.Category> GetAll() => _categoryService.GetCategories();


        // GET api/<CategoryController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}



        //// PUT api/<CategoryController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CategoryController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
