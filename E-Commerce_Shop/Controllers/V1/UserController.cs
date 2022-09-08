using Domain;
using E_Commerce_Shop.Contracts.V1;
using E_Commerce_Shop.Contracts.V1.DTO_requests;
using E_Commerce_Shop.Contracts.V1.DTO_responses;
using Logic.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userService.GetUsers();
        }

        [HttpGet(ApiRoutes.Users.GetUserByID)]
        public IActionResult GetUserById([FromRoute] int userId)
        {
            if (_userService.GetUserById(userId) == null)
                return NotFound();

            return Ok(_userService.GetUserById(userId));
        }

        [HttpPost(ApiRoutes.Users.AddUser)]
        public IActionResult AddUser([FromBody] CreateUserRequestDTO dto)
        {
            var user = new User()
            {
                Name = dto.Name,
                Surname = dto.Surname,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                Adress = dto.Adress
            };

            _userService.CreateUser(user);

            var response = new CreateUserResponseDTO()
            {
                Id = user.Id
            };

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Users.GetUserByID.Replace("{userId}", response.Id.ToString());
            return Created(locationUri, response);
            //return CreatedAtRoute("api/v1/GetUserById", new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] User updatedUser)
        {
            if (updatedUser == null || updatedUser.Id != id)
            {
                return BadRequest();
            }

            var userToUpdate = _userService.GetUserById(id);

            if (userToUpdate == null)
            {
                return NotFound();
            }

            _userService.Update(updatedUser);

            return RedirectToRoute("api/v1/GetAllUsers");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var userToDelete = _userService.GetUserById(id);

            if (userToDelete == null)
            {
                return BadRequest();
            }

            return Ok(userToDelete);
        }
    }
}
