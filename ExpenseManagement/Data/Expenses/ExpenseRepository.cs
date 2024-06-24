using ExpenseManagement.Entities;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExpenseManagement.Data.Expenses
{
    public class ExpenseRepository:RepositoryBase<Expense, ApplicationDbContext>, IExpenseRepository
    {

        ApplicationDbContext _context;
        public ExpenseRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) 
        {
            _context = applicationDbContext;
        }

        public async Task<List<Expense>> FindbyDate(DateTime date)
        {
            return await _context.Expenses.Where(e => e.DateTime.Date == date.Date).ToListAsync();
        }

        public async Task<List<Expense>> FindbyDateandUser(DateTime date, string userid)
        {
            return await _context.Expenses.Where(e => e.DateTime.Date == date.Date && e.UserID == userid).ToListAsync();
        }

        public async Task<List<Expense>> FindbyMonth(int month)
        {
            return await _context.Expenses.Where(e => e.DateTime.Month == month).ToListAsync();
        }

        public async Task<List<Expense>> FindbyMonthandUser(int month, string userid)
        {
            return await _context.Expenses.Where(e => e.DateTime.Month == month && e.UserID == userid).ToListAsync();
        }

        public async Task<List<Expense>> FindbyUserID(string userid)
        {
            return await _context.Expenses.Where(e => e.UserID == userid).ToListAsync();
        }
    }
}
