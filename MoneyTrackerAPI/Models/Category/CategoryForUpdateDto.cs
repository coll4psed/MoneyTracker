using System.ComponentModel.DataAnnotations;

namespace MoneyTrackerAPI.Models.Category
{
    public class CategoryForUpdateDto
    {
        [MaxLength(50)]
        public string CategoryName { get; set; } = null!;
    }
}
