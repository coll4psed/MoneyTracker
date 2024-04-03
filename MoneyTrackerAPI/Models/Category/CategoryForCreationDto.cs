using System.ComponentModel.DataAnnotations;

namespace MoneyTrackerAPI.Models.Category
{
    public class CategoryForCreationDto
    {
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; } = null!;

        [Required]
        public int CategoryTypeId { get; set; }
    }
}
