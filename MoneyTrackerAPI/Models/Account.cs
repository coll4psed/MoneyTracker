using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyTrackerAPI.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Value { get; set; }
        [Required]
        [MaxLength(40)]
        public string AccountName { get; set; } = null!;

        public List<Expense> Expenses { get; set; } = new();
        public List<Income> Incomes { get; set; } = new();
    }
}