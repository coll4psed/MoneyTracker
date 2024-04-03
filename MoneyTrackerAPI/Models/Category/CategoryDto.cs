using MoneyTrackerAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace MoneyTrackerAPI.Models.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string CategoryName { get; set; }
        [Required]
        public int CategoryType { get; set; }
    }
}
