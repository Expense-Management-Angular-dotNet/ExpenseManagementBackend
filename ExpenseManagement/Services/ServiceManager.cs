using AutoMapper;
using ExpenseManagement.Data;
using ExpenseManagement.Entities;
using ExpenseManagement.Services.AuthService;
using ExpenseManagement.Services.ExpenseServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace ExpenseManagement.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthService> _authService;
        private readonly Lazy<UserService> _userService;
        private readonly Lazy<ExpenseService> _expenseService;

        public ServiceManager(UserManager<User> userManager, IConfiguration configuration, SignInManager<User> signInManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _authService = new Lazy<IAuthService>(() => new AuthService.AuthService(userManager, signInManager, mapper, configuration));
            _expenseService = new Lazy<ExpenseService>(() => new ExpenseService(unitOfWork, mapper));
            _userService = new Lazy<UserService>(() => new UserService(userManager, signInManager, mapper, configuration));
        }

        public IAuthService AuthService => _authService.Value;
        public UserService UserService => _userService.Value;
        public ExpenseService ExpenseService => _expenseService.Value;
    }
}
