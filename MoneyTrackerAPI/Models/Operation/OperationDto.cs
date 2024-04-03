using System.ComponentModel.DataAnnotations;

namespace MoneyTrackerAPI.Models.Operation
{
    public class OperationDto
    {
        public long Id { get; set; }

        [Required, DataType(DataType.Currency)]
        public decimal Value { get; set; }

        [Required, DataType(DataType.Date)]
        public DateOnly Date {  get; set; }

        [MaxLength(250)]
        public string? Comment { get; set; }

        [Required]
        public long CategoryId { get; set; }

        [Required]
        public long AccountId { get; set; }
    }
}
