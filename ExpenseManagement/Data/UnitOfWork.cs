using ExpenseManagement.Data.Expenses;
using ExpenseManagement.Data.Users;
using ExpenseManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagement.Data
{
    public class UnitOfWork : IUnitOfWork
    {   

        private readonly ApplicationDbContext _context;
        private readonly Lazy<IExpenseRepository> _expenseRepository;
        private readonly Lazy<IUserRepository> _userRepository;

        public UnitOfWork(ApplicationDbContext context) { 
            _context = context;
            _expenseRepository = new Lazy<IExpenseRepository>(() => new ExpenseRepository(_context));
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(_context));

        }
        public IExpenseRepository ExpenseRepository => _expenseRepository.Value;

        public IUserRepository UserRepository => _userRepository.Value;

        public void save()
        {
            _context.SaveChanges();
        }
    }
}
