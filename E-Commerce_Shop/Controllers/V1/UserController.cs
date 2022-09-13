using Domain;
using E_Commerce_Shop.Contracts.V1;
using E_Commerce_Shop.Contracts.V1.DTO_requests;
using E_Commerce_Shop.Contracts.V1.DTO_responses;
using Logic.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Shop.Controllers.V1
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet(ApiRoutes.Users.GetAllUsers)]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userService.GetUsersAsync());
        }

        [HttpGet(ApiRoutes.Users.GetUserByID)]
        public async Task<IActionResult> GetUserById([FromRoute] int userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost(ApiRoutes.Users.AddUser)]
        public async Task<IActionResult> AddUser([FromBody] CreateUserRequestDTO request)
        {
            await _userService.CreateUserAsync(new User()
            {
                Name = request.Name,
                Surname = request.Surname,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Adress = request.Adress
            });

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Users.GetUserByID
                .Replace("{userId}", (await _userService.GetUsersAsync()).Last().Id.ToString());

            return Created(locationUri, new CreateUserResponseDTO() { Id = (await _userService.GetUsersAsync()).Last().Id });
        }

        [HttpPut(ApiRoutes.Users.UpdateUser)]
        public async Task<IActionResult> UpdateUser([FromRoute] int userId, [FromBody] UpdateUserRequestDTO request)
        {
            var user = new User
            {
                Id = userId,
                Name = request.Name,
                Surname = request.Surname,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Adress = request.Adress
            };

            var updated = await _userService.UpdateUserAsync(user);

            if (updated)
                return Ok(user);

            return NotFound();
        }

        [HttpDelete(ApiRoutes.Users.DeleteUser)]
        public async Task<IActionResult> DeleteUser([FromRoute] int userId)
        {
            var deleted = await _userService.DeleteUserAsync(userId);

            if (deleted)
                return NoContent();

            return NotFound();
        }
    }
}
