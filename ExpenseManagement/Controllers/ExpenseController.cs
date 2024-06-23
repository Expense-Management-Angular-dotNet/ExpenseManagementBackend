using ExpenseManagement.Entities;
using ExpenseManagement.Services;
using ExpenseManagement.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExpenseManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly IServiceManager _service;

        public ExpenseController(IServiceManager service)
        {
            _service = service;
        }

        [HttpPost("Create")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> createExpense(ExpenseDTO expenseDTO)
        {
            if (expenseDTO == null)
            {
                return BadRequest(ModelState);
            }

            var token = Request.Headers["Authorization"];
            Console.WriteLine("Token", token);

            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Console.WriteLine($"UserID is: {userId}");

                _service.ExpenseService.createExpense(expenseDTO, userId);

                return Ok(new { message = "Expense is added" });

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex}\nStack Trace: {ex.StackTrace}");
                return StatusCode(500, "Internal server error");

            }

        }


    }
}
