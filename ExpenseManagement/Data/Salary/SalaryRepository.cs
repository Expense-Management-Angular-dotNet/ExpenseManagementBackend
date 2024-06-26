using ExpenseManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagement.Data.Salaries
{
    public class SalaryRepository : RepositoryBase<SalaryRecord, ApplicationDbContext>, ISalaryRepository
    {
        private readonly ApplicationDbContext _context;

        public SalaryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task CreateSalaryRecord(SalaryRecord salaryRecord)
        {
            // Check for an existing record with the same userId, month, and year
            var existingRecord = await _context.SalaryRecords
                .FirstOrDefaultAsync(sr => sr.UserID == salaryRecord.UserID
                                           && sr.LastChangedDate.Month == salaryRecord.LastChangedDate.Month
                                           && sr.LastChangedDate.Year == salaryRecord.LastChangedDate.Year);

            if (existingRecord != null)
            {
                // Update the existing record
                existingRecord.Amount = salaryRecord.Amount;
            }
            else
            {
                // Create a new record
                salaryRecord.SalaryRecordID = Guid.NewGuid().ToString();
                _context.SalaryRecords.Add(salaryRecord);
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateSalaryRecord(SalaryRecord updatedSalaryRecord)
        {
            var existingRecord = await _context.SalaryRecords
                .FirstOrDefaultAsync(sr => sr.SalaryRecordID == updatedSalaryRecord.SalaryRecordID);

            if (existingRecord != null)
            {
                // Update fields if they are not null
                if (updatedSalaryRecord.Amount != 0)
                {
                    existingRecord.Amount = updatedSalaryRecord.Amount;
                }

                if (updatedSalaryRecord.LastChangedDate != DateTime.MinValue)
                {
                    existingRecord.LastChangedDate = updatedSalaryRecord.LastChangedDate;
                }

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Salary record not found.");
            }
        }

        public async Task<SalaryRecord> GetSalaryRecordById(string id)
        {
            return await _context.SalaryRecords.FindAsync(id);
        }

        public async Task<List<SalaryRecord>> GetSalaryRecordsByUserId(string userId)
        {
            return await _context.SalaryRecords.Where(s => s.UserID == userId).ToListAsync();
        }

        public async Task<SalaryRecord> GetSalaryByMonthAndUserId(string userId, int year, int month)
        {
            return await _context.SalaryRecords
                .Where(s => s.UserID == userId && s.LastChangedDate.Year <= year && s.LastChangedDate.Month <= month)
                .OrderByDescending(s => s.LastChangedDate)
                .FirstOrDefaultAsync();
        }

        public async Task<List<SalaryRecord>> GetSalariesByYearAndUserId(string userId, int year)
        {
            return await _context.SalaryRecords
                .Where(s => s.UserID == userId && s.LastChangedDate.Year <= year)
                .OrderByDescending(s => s.LastChangedDate)
                .GroupBy(s => s.LastChangedDate.Month)
                .Select(g => g.First())
                .ToListAsync();
        }
    }
}
