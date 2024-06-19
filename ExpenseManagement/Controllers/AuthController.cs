using ExpenseManagement.Services;
using ExpenseManagement.Services.AuthService;
using ExpenseManagement.Shared;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IServiceManager _service;

       
        public AuthController(IServiceManager service) { 
            _service = service;
        }

        [HttpPost("Create")]
/*        [Authorize(Roles = "Admin")]*/
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
            if (!await _service.AuthService.LoginAsync(user)) { return Unauthorized(); }
           
                
            return Ok(await _service.AuthService.generateToken());
        }
    }
}
