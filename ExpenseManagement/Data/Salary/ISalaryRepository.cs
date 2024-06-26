using ExpenseManagement.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseManagement.Data.Salaries
{
    public interface ISalaryRepository
    {
        Task CreateSalaryRecord(SalaryRecord salaryRecord);
        Task UpdateSalaryRecord(SalaryRecord salaryRecord);
        Task<SalaryRecord> GetSalaryRecordById(string id);
        Task<List<SalaryRecord>> GetSalaryRecordsByUserId(string userId);
        Task<SalaryRecord> GetSalaryByMonthAndUserId(string userId, int year, int month);
        Task<List<SalaryRecord>> GetSalariesByYearAndUserId(string userId, int year);
    }
}
