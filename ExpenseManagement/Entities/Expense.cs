using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseManagement.Entities
{
    public class Expense
    {
        [Key]
        public string ExpenseID { get; set; }
        public string? ExpenseType { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Amount { get; set; }


        public string? UserID { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
