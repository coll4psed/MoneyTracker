using System.ComponentModel.DataAnnotations;

namespace MoneyTrackerAPI.Models.Account
{
    public class AccountForCreationDto
    {
        [DataType(DataType.Currency)]
        public decimal Value { get; set; }

        [MaxLength(40)]
        public string AccountName { get; set; } = null!;
    }
}
