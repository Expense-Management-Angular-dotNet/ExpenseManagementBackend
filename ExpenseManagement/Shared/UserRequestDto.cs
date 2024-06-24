namespace ExpenseManagement.Shared
{
    public class UserRequestDto
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? UserType { get; set; }
        public string? Title { get; set; }
        public int? Salary { get; set; }
        public string? ManagerEmail { get; set; }
        public bool? IsVerified { get; set; }
    }
}
