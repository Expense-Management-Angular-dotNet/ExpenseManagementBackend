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
        private readonly Lazy<UserService> _userService;

        public ServiceManager(UserManager<User> userManager, IConfiguration configuration, SignInManager<User> signInManager, IMapper mapper, IConfiguration configuration1)
        {
            _authService = new Lazy<IAuthService>(() => new AuthService.AuthService(userManager, signInManager, mapper, configuration1));
            _userService = new Lazy<UserService>(() => new UserService(userManager, signInManager, mapper, configuration1));
        }

        public IAuthService AuthService => _authService.Value;
        public UserService UserService => _userService.Value;
    }
}
