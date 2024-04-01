using System.ComponentModel.DataAnnotations;

namespace MoneyTrackerAPI.Models.Category
{
    public class ExpenseCategoryForCreationDto
    {
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; } = string.Empty;
    }
}
