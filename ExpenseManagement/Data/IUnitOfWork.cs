using ExpenseManagement.Data.Expenses;
using ExpenseManagement.Data.Salaries;
using ExpenseManagement.Data.Users;

namespace ExpenseManagement.Data
{
    public interface IUnitOfWork
    {
        IExpenseRepository ExpenseRepository { get; }
        IUserRepository UserRepository { get; }
        ISalaryRepository SalaryRepository { get; }

        Task save();
    }
}
