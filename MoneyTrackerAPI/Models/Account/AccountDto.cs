using MoneyTrackerAPI.Entities;

namespace MoneyTrackerAPI.Models.Account
{
    public class AccountDto
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public string AccountName { get; set; } = null!;

        public List<Expense> Expenses { get; set; } =
            new List<Expense>();
        public List<Income> Incomes { get; set; } =
            new List<Income>();
    }
}
