using AutoMapper;
using ExpenseManagement.Entities;
using ExpenseManagement.Services.AuthService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace ExpenseManagement.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthService> _authService;

        public ServiceManager(UserManager<User> userManager, IConfiguration configuration, SignInManager<User> signInManager, IMapper mapper)
        {
            _authService = new Lazy<IAuthService>(() => new AuthService.AuthService(userManager, signInManager, mapper));
        }

        public IAuthService AuthService => _authService.Value;
    }
}
