using System.ComponentModel.DataAnnotations;

namespace ExpenseManagement.Shared
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password name is required")]
        public string? Password { get; init; }

    }
}
