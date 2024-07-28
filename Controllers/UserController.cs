using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Models;
using TaskManagementSystem.Repositories;

namespace TaskManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userService;

        public UserController(IUserRepository userService)
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
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.ID }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _userService.UpdateUserAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.ID }, user);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = _userService.DeleteUserAsync(id);
            return Ok(true);
        }

        //Login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool isValidUser = await _userService.ValidateUserCredentialsAsync(login);
            if (!isValidUser)
                return Unauthorized();

            // Return appropriate response, e.g., a token or success message
            return Ok(new { Message = "Login successful" });
        }
        // Additional endpoints for updating, deleting, and managing Users
    }

}
