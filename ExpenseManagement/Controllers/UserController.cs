using ExpenseManagement.Services;
using ExpenseManagement.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        [Authorize(AuthenticationSchemes = "Bearer", Policy = "AdminOrSelf")]
        public async Task<IActionResult> UpdateUser([FromBody] UserRequestDto userRequestDto)
        {
            Console.WriteLine("--------------------------entered");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var userEmail = User.FindFirstValue(ClaimTypes.Email);

            //var user = await _userService.GetUserByIdAsync(userId);
            //Console.WriteLine($"--------------------------userId : {userId}");
            //Console.WriteLine($"--------------------------userEmail : {userEmail}");

            //if (user.UserType == "Admin" || user.Email == userRequestDto.Email)
            //{
                Console.WriteLine("--------------------------authorized");

                var result = await _userService.UpdateUserAsync(userRequestDto);

                if (result.Succeeded)
                {
                    return Ok("user updated successfully");
                }

                return BadRequest(result.Errors);
            //}
            //else
            //{
            //    Console.WriteLine("--------------------------unauthorized");
            //    return Unauthorized();
            //}

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
