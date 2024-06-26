using ExpenseManagement.Entities;
using ExpenseManagement.Services;
using ExpenseManagement.Services.SalaryServices;
using ExpenseManagement.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExpenseManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalaryController : ControllerBase
    {
        private readonly ISalaryService _salaryService;
        private readonly IServiceManager _service;
        private readonly UserService _userService;

        public SalaryController(IServiceManager service)
        {
            _service = service;
            _userService = _service.UserService;
            _salaryService = _service.SalaryService;
        }

        [HttpPost("Create")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> CreateSalaryRecord(SalaryDto salaryDto)
        {
            if (salaryDto == null)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _salaryService.CreateSalaryRecord(salaryDto);
                return Ok(new { message = "Salary record is added" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex}\nStack Trace: {ex.StackTrace}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("Update")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> UpdateSalaryRecord(SalaryDto salaryDto)
        {
            Console.WriteLine("entered the controller.");

            if (salaryDto == null)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _salaryService.UpdateSalaryRecord(salaryDto);
                return Ok(new { message = "Salary record is updated" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex}\nStack Trace: {ex.StackTrace}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetOne/{salaryId}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetSalaryRecordById(string salaryId)
        {
            try
            {
                var salaryDto = await _salaryService.GetSalaryRecordById(salaryId);

                if (salaryDto == null)
                {
                    return NotFound("Salary record not found");
                }

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var userEmail = User.FindFirstValue(ClaimTypes.Email);

                var user = await _userService.GetUserByIdAsync(userId);

                if (user.UserType == "Admin" || user.Id == salaryDto.UserID)
                {
                    return Ok(salaryDto);

                }
                else
                {
                    return Unauthorized();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex}\nStack Trace: {ex.StackTrace}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetAll/{user_id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetSalaryRecordsByUserId(string user_id)
        {
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var user = _userService.GetUserByIdAsync(userId).Result;

                if (user.UserType != "Admin" && user.Id != user_id )
                {
                    return Unauthorized("Forbidden");

                }
                else
                {

                    var salaryRecords = await _salaryService.GetSalaryRecordsByUserId(userId);

                    if (salaryRecords == null || salaryRecords.Count == 0)
                    {
                        return NotFound("No salary records found for this user");
                    }

                    return Ok(salaryRecords);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex}\nStack Trace: {ex.StackTrace}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetOneMonthSalary/{user_id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetSalaryByMonthAndUserId(string user_id, [FromQuery] int year, [FromQuery] int month)
        {
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var user = _userService.GetUserByIdAsync(userId).Result;

                if (user.UserType != "Admin" && user.Id != user_id)
                {
                    return Unauthorized("Forbidden");

                }
                else
                {

                    var salaryRecord = await _salaryService.GetSalaryByMonthAndUserId(userId, year, month);

                    if (salaryRecord == null)
                    {
                        return NotFound("No salary record found for this month and user");
                    }

                    return Ok(salaryRecord);


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex}\nStack Trace: {ex.StackTrace}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetOneYearSalaries/{user_id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetSalariesByYearAndUserId(string user_id, [FromQuery] int year)
        {
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var user = _userService.GetUserByIdAsync(userId).Result;

                if (user.UserType != "Admin" && user.Id != user_id)
                {
                    return Unauthorized("Forbidden");

                }
                else
                {

                    var salaryRecords = await _salaryService.GetSalariesByYearAndUserId(userId, year);

                    if (salaryRecords == null || salaryRecords.Count == 0)
                    {
                        return NotFound("No salary records found for this year and user");
                    }

                    return Ok(salaryRecords);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex}\nStack Trace: {ex.StackTrace}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
