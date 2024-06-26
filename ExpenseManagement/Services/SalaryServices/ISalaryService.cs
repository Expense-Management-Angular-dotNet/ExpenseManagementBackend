using ExpenseManagement.Entities;
using ExpenseManagement.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseManagement.Services.SalaryServices
{
    public interface ISalaryService
    {
        Task CreateSalaryRecord(SalaryDto salaryDto);
        Task UpdateSalaryRecord(SalaryDto salaryDto);
        Task<SalaryDto> GetSalaryRecordById(string id);
        Task<List<SalaryDto>> GetSalaryRecordsByUserId(string userId);
        Task<SalaryDto> GetSalaryByMonthAndUserId(string userId, int year, int month);
        Task<List<SalaryDto>> GetSalariesByYearAndUserId(string userId, int year);
    }
}
