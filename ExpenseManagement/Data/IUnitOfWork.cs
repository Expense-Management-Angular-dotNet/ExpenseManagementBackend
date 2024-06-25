using ExpenseManagement.Data.Expenses;
using ExpenseManagement.Data.Users;

namespace ExpenseManagement.Data
{
    public interface IUnitOfWork
    {
        IExpenseRepository ExpenseRepository { get; }
        IUserRepository UserRepository { get; }

        Task save();
    }
}
