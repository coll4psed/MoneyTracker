using MoneyTrackerAPI.Entities;

namespace MoneyTrackerAPI.Models.Account
{
    public class AccountDto
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public string AccountName { get; set; } = null!;
    }
}