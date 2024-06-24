namespace ExpenseManagement.Shared
{
    public class UserResponseDto
    {
        public string? Name { get; set; }
        public string? UserType { get; set; }

        public string? Tittle { get; set; }

        public int? Salary { get; set; }

        public bool? IsVerified { get; set; }
    }
}
