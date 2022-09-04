using Domain;
using E_Commerce_Shop.Contracts.V1;
using E_Commerce_Shop.DTO;
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

        [HttpGet("{id}", Name = "api/v1/GetUserById")]
        public IActionResult GetUserById(int id)
        {
            if (_userService.GetUserById(id) == null)
            {
                return NotFound();
            }

            return Ok(_userService.GetUserById(id));
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] CreateUserDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            _userService.CreateUser(new User()
            {
                Name = dto.Name,
                Surname = dto.Surname,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                Adress = dto.Adress
            });

            return CreatedAtRoute("api/v1/GetUserById", /*new { id = dto.Id },*/ dto);
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
