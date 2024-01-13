using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyTrackerAPI.Entities
{
    public class Expense
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Value { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateOnly ExpenseDate { get; set; }
        [MaxLength(255)]
        public string Comment { get; set; } = null!;

        public int ExpenseCategoryId { get; set; }
        public int AccountId { get; set; }

        public ExpenseCategory? ExpenseCategory { get; set; }
        public Account? Account { get; set; }
    }
}
