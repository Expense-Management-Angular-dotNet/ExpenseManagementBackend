using ExpenseManagement.Entities;

namespace ExpenseManagement.Data.Expenses
{
    public class ExpenseRepository : RepositoryBase<Expense>, IExpenseRepository
    {
        public ExpenseRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }

        public override void Update(Expense entity)
        {
            throw new NotImplementedException();
        }
    }
}
