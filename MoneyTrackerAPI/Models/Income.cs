using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyTrackerAPI.Models
{
    public class Income
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Value { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateOnly IncomeDate { get; set; }
        [MaxLength(255)]
        public string Comment { get; set; } = null!;

        public int IncomeCategoryId { get; set; }
        public int AccountId { get; set; }

        public IncomeCategory? IncomeCategory { get; set; }
        public Account? Account { get; set; }
    }
}
