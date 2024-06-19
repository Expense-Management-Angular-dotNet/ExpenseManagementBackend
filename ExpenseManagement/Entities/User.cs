using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ExpenseManagement.Entities
{
    public class User : IdentityUser
    {
        [Key]
        public string Id { get; set; }
        public string? Name { get; set; }
        /*public string? Email { get; set; }*/
        
/*        public string? Password { get; set; }*/

        public string? UserType { get; set; }

        public string? Tittle {  get; set; }

        public int? Salary { get; set; }

        public Boolean? IsVerified {  get; set; }

        public ICollection<Expense>? Expenses { get; set; }
        public ICollection<SalaryRecord>? SalaryRecords { get; set; }
    }
}
