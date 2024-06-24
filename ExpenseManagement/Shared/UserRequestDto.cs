﻿namespace ExpenseManagement.Shared
{
    public class UserRequestDto
    {
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? UserType { get; set; }
        public string? Tittle { get; set; }
        public int? Salary { get; set; }
        public string? ManagerEmail { get; set; }
        public bool? IsVerified { get; set; }
    }
}