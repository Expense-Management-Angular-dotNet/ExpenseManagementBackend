using Microsoft.AspNetCore.Identity;

namespace ExpenseManagement.Entities
{
    public class User : IdentityUser
    {
        /*[Key]*/
        /*        public string Id { get; set; } 
                public string? Email { get; set; }
                public string UserName { get; set; }       
                public string? Password { get; set; }*/
        public string? Name { get; set; }
        public string? UserType { get; set; }
        public string? Tittle { get; set; }
        public int? Salary { get; set; }
        public bool? IsVerified { get; set; }
        public string? ManagerEmail { get; set; }
        public ICollection<Expense>? Expenses { get; set; }
        public ICollection<SalaryRecord>? SalaryRecords { get; set; }
    }
}
