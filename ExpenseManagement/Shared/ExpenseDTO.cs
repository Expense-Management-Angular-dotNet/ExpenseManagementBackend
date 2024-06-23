namespace ExpenseManagement.Shared
{
    public class ExpenseDTO
    {
        public string? ExpenseType { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Amount { get; set; }
    }
}
