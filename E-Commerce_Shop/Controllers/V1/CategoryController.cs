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
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost(ApiRoutes.Categories.AddCategory)]
        public async Task<IActionResult> AddCategory([FromBody] CreateCategoryRequestDTO request)
        {
            await _categoryService.CreateCategoryAsync(new Category()
            {
                Name = request.Name,
                Description = request.Description
            });

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Categories.GetCategoryByID.Replace("{categoryId}", (await _categoryService
                .GetAllCategoriesAsync()).Last().ToString());

            return Created(locationUri, new CreateCategoryResponseDTO() { Id = (await _categoryService.GetAllCategoriesAsync()).Last().Id });

        }

        [HttpGet(ApiRoutes.Categories.GetAllCategories)]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(await _categoryService.GetAllCategoriesAsync());
        }

        [HttpGet(ApiRoutes.Categories.GetCategoryByID)]
        public async Task<IActionResult> GetCategoryById([FromRoute] int categoryId)
        {
            var category = await _categoryService.GetCategoryByIdAsync(categoryId);

            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPut(ApiRoutes.Categories.UpdateCategory)]
        public async Task<IActionResult> UpdateCategory([FromRoute] int categoryId, [FromBody] UpdateCategoryRequestDTO request)
        {
            var category = new Category
            {
                Id = categoryId,
                Name = request.Name,
                Description = request.Description
            };

            var updated = await _categoryService.UpdateCategoryAsync(category);

            if (updated)
                return Ok(category);

            return NotFound();
        }

        [HttpDelete(ApiRoutes.Categories.DeleteCategory)]
        public async Task<IActionResult> DeleteCategory([FromRoute] int categoryId)
        {
            var deleted = await _categoryService.DeleteCategoryAsync(categoryId);

            if (deleted)
                return NoContent();

            return NotFound();
        }
    }
}
