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
        private readonly Lazy<ExpenseService> _expenseService;

        public ServiceManager(UserManager<User> userManager, IConfiguration configuration, SignInManager<User> signInManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _authService = new Lazy<IAuthService>(() => new AuthService.AuthService(userManager, signInManager, mapper, configuration));
            _expenseService = new Lazy<ExpenseService>(() => new ExpenseService(unitOfWork, mapper));
        }

        public IAuthService AuthService => _authService.Value;
        public ExpenseService ExpenseService => _expenseService.Value;
    }
}
