using System.ComponentModel.DataAnnotations;

namespace MoneyTrackerAPI.Models.Operation
{
    public class OperationForCreationDto
    {
        [Required, DataType(DataType.Currency)]
        public decimal Value { get; set; }

        [Required, DataType(DataType.Date)]
        public DateOnly Date { get; set; }

        [MaxLength(250)]
        public string? Comment { get; set; }

        public long CategoryId { get; set; }
        public long AccountId { get; set; }
    }
}
