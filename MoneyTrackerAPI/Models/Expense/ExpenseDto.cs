namespace MoneyTrackerAPI.Models.Expense
{
    public class ExpenseDto
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public DateOnly ExpenseDate { get; set; }
        public string Comment { get; set; } = string.Empty!;
    }
}
