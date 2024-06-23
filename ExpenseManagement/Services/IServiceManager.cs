
using ExpenseManagement.Services.AuthService;
using ExpenseManagement.Services.ExpenseServices;
using Microsoft.AspNetCore.Authentication;

namespace ExpenseManagement.Services
{
    public interface IServiceManager
    {
        IAuthService AuthService { get; }
        ExpenseService ExpenseService { get; }
    }
}
