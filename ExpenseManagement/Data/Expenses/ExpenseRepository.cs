using ExpenseManagement.Entities;

namespace ExpenseManagement.Data.Expenses
{
    public class ExpenseRepository:RepositoryBase<Expense, ApplicationDbContext>, IExpenseRepository
    {
        public ExpenseRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }
    }
}
