using MoneyTrackerAPI.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyTrackerAPI.Models
{
    public class Income : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal Value { get; set; }
        public DateOnly Date { get; set; }
        public string Comment { get; set; }

        public int IncomeCategoryId { get; set; }
        public int AccountId { get; set; }

        public IncomeCategory? IncomeCategory { get; set; }
        public Account? Account { get; set; }
    }
}
