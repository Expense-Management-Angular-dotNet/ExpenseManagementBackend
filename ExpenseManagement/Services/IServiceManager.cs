
using ExpenseManagement.Services.AuthService;
using Microsoft.AspNetCore.Authentication;

namespace ExpenseManagement.Services
{
    public interface IServiceManager
    {
        IAuthService AuthService { get; }
        UserService UserService { get; }
    }
}
