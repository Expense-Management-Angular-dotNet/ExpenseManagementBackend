using ExpenseManagement.Data.Expenses;
using ExpenseManagement.Data.Salaries;
using ExpenseManagement.Data.Users;
using ExpenseManagement.Entities;

namespace ExpenseManagement.Data
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _context;
        private readonly Lazy<IExpenseRepository> _expenseRepository;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<ISalaryRepository> _salaryRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            _expenseRepository = new Lazy<IExpenseRepository>(() => new ExpenseRepository(_context));
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(_context));
            _salaryRepository = new Lazy<ISalaryRepository>(() => new SalaryRepository(_context));

        }
        public IExpenseRepository ExpenseRepository => _expenseRepository.Value;

        public IUserRepository UserRepository => _userRepository.Value;
        public ISalaryRepository SalaryRepository => _salaryRepository.Value;

        public async Task save()
        {
           await _context.SaveChangesAsync();
        }
    }
}
