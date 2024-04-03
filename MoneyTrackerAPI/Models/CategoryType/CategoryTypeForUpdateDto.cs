using System.ComponentModel.DataAnnotations;

namespace MoneyTrackerAPI.Models.CategoryType
{
    public class CategoryTypeForUpdateDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
