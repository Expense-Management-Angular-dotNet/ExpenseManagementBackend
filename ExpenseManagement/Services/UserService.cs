using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExpenseManagement.Entities;
using ExpenseManagement.Shared;
using Microsoft.AspNetCore.Identity;

namespace ExpenseManagement.Services
{
    public class UserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<User> _signInManager;
        private User? _user;

        private static readonly string[] ValidUserTypes = { "Admin", "Manager", "User" };

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<User> GetUserByEmailAsync(UserRequestDto userDto)
        {
            var _user = await _userManager.FindByEmailAsync(userDto.Email);
            return _user;
        }

        public async Task<IdentityResult> UpdateUserAsync(UserRequestDto userRequestDto)
        {
            var user = await _userManager.FindByEmailAsync(userRequestDto.Email);

            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found" });
            }

            // Map only non-null properties from UserRequestDto to ApplicationUser
            if (!string.IsNullOrWhiteSpace(userRequestDto.Email))
            {
                user.Email = userRequestDto.Email;
                user.UserName = userRequestDto.Email; // Assuming username is the email
            }
            if (!string.IsNullOrWhiteSpace(userRequestDto.Name))
            {
                user.Name = userRequestDto.Name;
            }
            if (!string.IsNullOrWhiteSpace(userRequestDto.UserType) && ValidUserTypes.Contains(userRequestDto.UserType))
            {
                user.UserType = userRequestDto.UserType;
            }
            if (!string.IsNullOrWhiteSpace(userRequestDto.Title))
            {
                user.Title = userRequestDto.Title;
            }
            if (userRequestDto.Salary.HasValue)
            {
                user.Salary = userRequestDto.Salary.Value;
            }
            if (userRequestDto.IsVerified.HasValue)
            {
                user.IsVerified = userRequestDto.IsVerified.Value;
            }
            if (!string.IsNullOrWhiteSpace(userRequestDto.ManagerEmail))
            {
                user.ManagerEmail = userRequestDto.ManagerEmail;
            }

            var result = await _userManager.UpdateAsync(user);
            return result;
        }

        public async Task<IQueryable<UserResponseDto>> SearchUsersAsync(string? email, string? name, int? salary, string? managerEmail)
        {
            var users = _userManager.Users;

            if (!string.IsNullOrWhiteSpace(email))
            {
                users = users.Where(u => u.Email == email);
            }

            if (!string.IsNullOrWhiteSpace(name))
            {
                users = users.Where(u => u.Name.Contains(name));
            }

            if (salary.HasValue)
            {
                users = users.Where(u => u.Salary == salary.Value);
            }

            if (!string.IsNullOrWhiteSpace(managerEmail))
            {
                users = users.Where(u => u.ManagerEmail == managerEmail);
            }

            IQueryable<UserResponseDto> userDtos = users.ProjectTo<UserResponseDto>(_mapper.ConfigurationProvider);

            return userDtos;
        }


        public async Task<bool> hasManager(string email, string userId)
        {
            User? user = await _userManager.FindByIdAsync(userId);
            if(userId == null || email == null)
            {
                throw new ArgumentNullException(nameof(email), nameof(userId));
            }
            if (user == null)
            {
                IdentityError errors = new IdentityError { Description = $"User with UserId {userId} not found." };
            }
            if (user.ManagerEmail == email)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
