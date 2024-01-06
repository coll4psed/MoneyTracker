using MoneyTrackerAPI.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyTrackerAPI.Models
{
    public class Expense : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal Value { get; set; }
        public DateOnly Date { get; set; }
        public string Comment { get; set; }

        public int ExpenseCategoryId { get; set; }
        public int AccountId { get; set; }

        public ExpenseCategory? ExpenseCategory { get; set; }
        public Account? Account { get; set; }
    }
}
