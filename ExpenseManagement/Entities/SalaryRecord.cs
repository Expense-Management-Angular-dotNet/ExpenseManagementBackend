using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseManagement.Entities
{
    public class SalaryRecord
    {
        [Key]
        public string SalaryRecordID { get; set; }

        public decimal Amount { get; set; }
        public DateTime LastChangedDate { get; set; }

        public string? UserID { get; set; }
        [ForeignKey("UserId")] 

        public User User { get; set; }
    }
}
