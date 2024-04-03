using System.ComponentModel.DataAnnotations;

namespace MoneyTrackerAPI.Models.CategoryType
{
    public class CategoryTypeDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
