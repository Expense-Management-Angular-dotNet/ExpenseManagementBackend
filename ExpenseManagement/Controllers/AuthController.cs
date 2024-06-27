using ExpenseManagement.Services;
using ExpenseManagement.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IServiceManager _service;


        public AuthController(IServiceManager service)
        {
            _service = service;
        }

        [HttpPost("Create")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterDto model)
        {

            if (!ModelState.IsValid)
            {
                Console.WriteLine("something is not good with the model");
                return BadRequest(ModelState); // Return validation errors if model state is invalid
            }

            var result = await _service.AuthService.RegisterAsync(model);
            if (!result.Succeeded)
            {
                Console.WriteLine("something is not good with the result");
                foreach (var error in result.Errors)
                {
                    Console.WriteLine($"Error: {error} and code is: {error.Code}");
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] LoginDto user)
        {

            var (result, activated) = await _service.AuthService.LoginAsync(user);
            if (!result) { return Unauthorized(); }

            if (!activated)
            {
                /*var updatePasswordUrl = "http://localhost:/update-password";
                Response.Headers["Location"] = updatePasswordUrl;*/
                return StatusCode(StatusCodes.Status303SeeOther, new { message = "Account is not verified. Please update your password." });//, redirectUrl = updatePasswordUrl });
            }

            var token = await _service.AuthService.generateToken();
            return Ok(new { token });
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordDto passwordDto)
        {
            var result = await _service.AuthService.UpdatePasswordAsync(passwordDto);
            if (!result.Succeeded) {
                return BadRequest(new {errors = result.Errors});
            }

           
            return Ok(new { message = "Password is updated" });
        }
    }
}
