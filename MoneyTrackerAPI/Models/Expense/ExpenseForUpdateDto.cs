using System.ComponentModel.DataAnnotations;

namespace MoneyTrackerAPI.Models.Expense
{
    public class ExpenseForUpdateDto
    {
        [Required]
        [DataType(DataType.Currency)]
        public decimal Value { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateOnly ExpenseDate { get; set; }
        [MaxLength(255)]
        public string? Comment { get; set; } = string.Empty;

        public int ExpenseCategoryId { get; set; }
        public int AccountId { get; set; }
    }
}
