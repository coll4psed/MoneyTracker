using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyTrackerAPI.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; } = null!;

        public List<ExpenseCategory> ExpensesCategory { get; set; } = new();
        public List<IncomeCategory> IncomesCategory { get; set; } = new();
    }
}
