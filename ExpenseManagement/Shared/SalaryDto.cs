namespace ExpenseManagement.Shared
{
    public class SalaryDto
    {
        public string? SalaryRecordID { get; set; }

        public decimal? Amount { get; set; }
        public int? month { get; set; }
        public int? year { get; set; }
        public string? UserID { get; set; }
    }
}
