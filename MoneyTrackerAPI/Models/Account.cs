using MoneyTrackerAPI.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyTrackerAPI.Models
{
    public class Account : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal Value { get; set; }
        public string Name { get; set; }

        public List<Expense> Expenses { get; set; } = new();
        public List<Income> Incomes { get; set; } = new();
    }
}