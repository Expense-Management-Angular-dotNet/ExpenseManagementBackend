using System.ComponentModel.DataAnnotations;

namespace ExpenseManagement.Shared
{
    public class RegisterDto
    {
        public string? Name { get; init; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; init; }
        public string? Title { get; set; }
        public string? UserType { get; set; }
        public int? Salary { get; set; }
    }
}
