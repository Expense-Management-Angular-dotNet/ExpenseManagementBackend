using ExpenseManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagement.Data.Expenses
{
    public class ExpenseRepository : RepositoryBase<Expense>, IExpenseRepository
    {

        ApplicationDbContext _context;
        public ExpenseRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) 
        {
            _context = applicationDbContext;
        }

        public Task<List<Expense>> FindbyUserID(string userid)
        {
            return _context.Expenses.Where(e => e.UserID == userid).ToListAsync();
        }
    }
}
