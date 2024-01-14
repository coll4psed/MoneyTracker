using System.ComponentModel.DataAnnotations;

namespace MoneyTrackerAPI.Models.Category
{
    public class CategoryForCreationDto
    {
        [MaxLength(50)]
        public string CategoryName { get; set; } = null!;
    }
}
