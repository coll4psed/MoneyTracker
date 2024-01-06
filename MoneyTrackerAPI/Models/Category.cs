using MoneyTrackerAPI.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyTrackerAPI.Models
{
    public class Category : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ExpenseCategory> ExpensesCategory { get; set; } = new();
        public List<IncomeCategory> IncomesCategory { get; set; } = new();
    }
}
