using AutoMapper;
using ExpenseManagement.Data;
using ExpenseManagement.Entities;
using ExpenseManagement.Services.AuthService;
using ExpenseManagement.Services.ExpenseServices;
using ExpenseManagement.Services.SalaryServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace ExpenseManagement.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthService> _authService;
        private readonly Lazy<UserService> _userService;
        private readonly Lazy<ExpenseService> _expenseService;
        private readonly Lazy<SalaryService> _salaryService;

        public ServiceManager(UserManager<User> userManager, IConfiguration configuration, SignInManager<User> signInManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _authService = new Lazy<IAuthService>(() => new AuthService.AuthService(userManager, signInManager, mapper, configuration));
            _expenseService = new Lazy<ExpenseService>(() => new ExpenseService(unitOfWork, mapper));
            _userService = new Lazy<UserService>(() => new UserService(userManager, signInManager, mapper, configuration));
            _salaryService = new Lazy<SalaryService>(() => new SalaryService(unitOfWork, mapper));
        }

        public IAuthService AuthService => _authService.Value;
        public UserService UserService => _userService.Value;
        public ExpenseService ExpenseService => _expenseService.Value;
        public SalaryService SalaryService => _salaryService.Value;
    }
}
