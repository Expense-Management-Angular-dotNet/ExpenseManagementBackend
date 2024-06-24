using ExpenseManagement.Entities;

namespace ExpenseManagement.Data.Expenses
{
    public interface IExpenseRepository : IRepositoryBase<Expense>
    {
        public Task <List<Expense>> FindbyUserID(string userid);
    }
}
