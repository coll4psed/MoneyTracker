using MoneyTrackerAPI.Entities;

namespace MoneyTrackerAPI.Models.Account
{
    public class AccountWithoutExpenseAndIncomeDto
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public string AccountName { get; set; } = null!;
    }
}