using ExpenseManagement.Entities;
using ExpenseManagement.Services;
using ExpenseManagement.Services.ExpenseServices;
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

        [HttpGet("Get")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetByUserID()
        {
            try
            {
            
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("User ID is missing");
                }

                var expenses = await _service.ExpenseService.GetbyUserID(userId);

                if (expenses == null || expenses.Count == 0)
                {
                    return NotFound("No expenses found for this user");
                }

                return Ok(expenses);
            }
            catch (Exception ex)
            {
                Console.WriteLine( $"An error occurred while retrieving expenses{ex}");
                return StatusCode(500, "Internal server error");
            }
        }



        [HttpPut("Update")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> UpdateExpense(Expense expense)
        {
            if (expense == null)
            {
                return BadRequest(ModelState);
            }
            try
            {


                _service.ExpenseService.updateExpense(expense);

                return Ok(new { message = "Expense is added" });

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex}\nStack Trace: {ex.StackTrace}");
                return StatusCode(500, "Internal server error");

            }

        }


        //!!!!!!!!!!************Under construction**********!!!!!!!!!!!
        [HttpGet("Get/{id}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin , Manager")]
        public async Task<IActionResult> GetByUserIDbyAdmin(string id)
        {
            try
            {
                string userId = id;

                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("User ID is missing");
                }

                var expenses = await _service.ExpenseService.GetbyUserID(userId);

                if (expenses == null || expenses.Count == 0)
                {
                    return NotFound("No expenses found for this user");
                }

                return Ok(expenses);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving expenses{ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetbyDate")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> GetByDate([FromQuery] DateTime date)
        {
            try
            {

               

                var expenses = await _service.ExpenseService.GetbyDate(date);

                if (expenses == null || expenses.Count == 0)
                {
                    return NotFound("No expenses found for this Date");
                }

                return Ok(expenses);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving expenses{ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetbyDate/{userId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> GetByDate([FromQuery] DateTime date, string userId)
        {
            try
            {
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("User ID is missing");
                }


                var expenses = await _service.ExpenseService.GetbyUserIdAndDate(date, userId);

                if (expenses == null || expenses.Count == 0)
                {
                    return NotFound("No expenses found for this Date");
                }

                return Ok(expenses);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving expenses{ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetbyMonth")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> GetByMonth([FromQuery] DateTime date)
        {
            try
            {
                var expenses = await _service.ExpenseService.GetbyMonth(date);

                if (expenses == null || expenses.Count == 0)
                {
                    return NotFound("No expenses found for this Date");
                }

                return Ok(expenses);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving expenses{ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetbyMonth/{userId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> GetbyMonth([FromQuery] DateTime date, string userId)
        {
            try
            {
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("User ID is missing");
                }


                var expenses = await _service.ExpenseService.GetbyUserIdAndMonth(date, userId);

                if (expenses == null || expenses.Count == 0)
                {
                    return NotFound("No expenses found for this Date");
                }

                return Ok(expenses);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving expenses{ex}");
                return StatusCode(500, "Internal server error");
            }
        }


    }
}
