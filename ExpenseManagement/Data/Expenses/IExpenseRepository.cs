using ExpenseManagement.Entities;

namespace ExpenseManagement.Data.Expenses
{
    public interface IExpenseRepository : IRepositoryBase<Expense>
    {
        public Task <List<Expense>> FindbyUserID(string userid);

        public Task<List<Expense>> FindbyDate(DateTime date);

        public Task<List<Expense>> FindbyMonth(int month);

        public Task<List<Expense>> FindbyDateandUser(DateTime date, string userid);

        public Task<List<Expense>> FindbyMonthandUser(int month, string userid);
    }
}
