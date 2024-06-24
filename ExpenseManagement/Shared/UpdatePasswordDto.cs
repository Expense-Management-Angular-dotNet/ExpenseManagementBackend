namespace ExpenseManagement.Shared
{
    public class UpdatePasswordDto
    {
        public string Email { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
