using ExpenseManagement.Shared;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using ExpenseManagement.Entities;

namespace ExpenseManagement.Services.AuthService
{
    public class AuthService : IAuthService
    {
        /*        private readonly ILoggerManager _logger;*/
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        /*        private readonly ILogger<AuthService> _logger;*/
        private readonly SignInManager<User> _signInManager;
        /*        private readonly IConfiguration _configuration1;*/
        private User? _user;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _configuration = configuration;

        }
        public async Task<(bool, bool)> LoginAsync(LoginDto model)
        {
            _user = await _userManager.FindByEmailAsync(model.Email);
            var result = (_user != null && await _userManager.CheckPasswordAsync(_user, model.Password));
            if (!result)
            {
                IdentityError errors = new IdentityError { Description = $"User with email {model.Email} not found." };
                /*return "Failed";*/
            }
            bool activated=true;
            if (_user.IsVerified != true)
            {
                activated = false;
            }
            
            //do generate token
            /*var token = await generateToken();
            return token;*/
            return (result, activated);
        }

        public async Task<IdentityResult> RegisterAsync(RegisterDto model)
        {
            var user = _mapper.Map<User>(model);
            user.IsVerified = false;
            user.UserName = model.Name.Replace(" ", "_");

            var result = await _userManager.CreateAsync(user, model.Password);
            Console.WriteLine($"The result is: {result.ToString()}");

            if (result.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, user.UserType);
                if (roleResult.Succeeded)
                {
                    // Reload the user to ensure the roles are updated
                    _user = await _userManager.FindByIdAsync(user.Id);
                    var roles = await _userManager.GetRolesAsync(_user);
                    Console.WriteLine($"Roles after assignment: {String.Join(", ", roles)}");
                }
                else
                {
                    Console.WriteLine("Failed to assign role to user.");
                }
            }

            return result;
        }


        public async Task<string> generateToken()
        {
            if (_user == null)
            {
                throw new Exception("User is not set.");
            }

            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
            var secret = new SymmetricSecurityKey(key);
            var signingCredentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, _user.Id),
                new(ClaimTypes.Email, _user.Email),
                new(ClaimTypes.Name, _user.Name ?? ""),
                new("Title", _user.Title ?? ""),
                new(ClaimTypes.Role, _user.UserType)
            };


            var roles = await _userManager.GetRolesAsync(_user);

            Console.WriteLine($"Found roles: {String.Join(", ", roles)}.");
            //foreach (var role in roles)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, role));
            //}

            var jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken
            (
                issuer: jwtSettings["validIssuer"],
                audience: jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }


        public async Task<IdentityResult> UpdatePasswordAsync(UpdatePasswordDto passwordDto)
        {
            var user = await _userManager.FindByEmailAsync(passwordDto.Email);
            if(user == null)
            {
                return IdentityResult.Failed(new IdentityError{ Description="User not found"});
            }

            var result = await _userManager.ChangePasswordAsync(user,passwordDto.CurrentPassword, passwordDto.NewPassword);
            if (result.Succeeded) {
                user.IsVerified = true;
                var updatedresult = await _userManager.UpdateAsync(user);
                if (!updatedresult.Succeeded)
                {
                    return IdentityResult.Failed(new IdentityError { Description = "Failed to update user verification status" });
                    }
            }

            return result;
        }
    }
}
