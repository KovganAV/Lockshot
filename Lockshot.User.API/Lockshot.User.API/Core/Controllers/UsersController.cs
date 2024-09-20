using Lockshot.User.API.Class;
using Lockshot.User.API.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lockshot.User.API.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
  
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            return Ok(user);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetUserByName(string Name) 
        {
            var user = await _userService.GetUserByNameAsync(Name);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            return Ok(user);
        }


        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserByEmailAsync(string Email)
        {
            var email = await _userService.GetUserByEmailAsync(Email);
            if (email == null)
            {
                return NotFound("User not found.");
            }
            return Ok(email);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
        {
            var user = await _userService.RegisterAsync(registerUserDto);
            if (user == null)
            {
                return BadRequest("Registration failed.");
            }
            return Ok(user);
        }
    }
}
