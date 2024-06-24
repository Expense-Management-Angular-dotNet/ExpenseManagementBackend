
using ExpenseManagement.Services.AuthService;
using ExpenseManagement.Services.ExpenseServices;
using Microsoft.AspNetCore.Authentication;

namespace ExpenseManagement.Services
{
    public interface IServiceManager
    {
        IAuthService AuthService { get; }
        UserService UserService { get; }
        ExpenseService ExpenseService { get; }
    }
}
