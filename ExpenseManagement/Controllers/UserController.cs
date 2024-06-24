using ExpenseManagement.Services;
using ExpenseManagement.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly UserService _userService;

        public UserController(IServiceManager service)
        {
            _service = service;
            _userService = _service.UserService;
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser([FromBody] UserRequestDto userRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userService.UpdateUserAsync(userRequestDto);

            if (result.Succeeded)
            {
                return Ok("User updated successfully");
            }

            return BadRequest(result.Errors);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchUsers([FromQuery] string? email, [FromQuery] string? name, [FromQuery] int? salary, [FromQuery] string? managerEmail)
        {
            var users = await _userService.SearchUsersAsync(email, name, salary, managerEmail);

            if (!users.Any())
            {
                return NotFound("No users found matching the criteria.");
            }

            return Ok(users);
        }
    }
}
