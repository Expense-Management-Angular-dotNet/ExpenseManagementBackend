﻿using ExpenseManagement.Shared;
using Microsoft.AspNetCore.Identity;


namespace ExpenseManagement.Services.AuthService
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterAsync(RegisterDto model);
        Task<(bool, bool)> LoginAsync(LoginDto model);

        Task<string> generateToken();
        public Task<IdentityResult> UpdatePasswordAsync(UpdatePasswordDto model);
    }
}
