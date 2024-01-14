using MoneyTrackerAPI.Entities;

namespace MoneyTrackerAPI.Models.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public List<ExpenseCategory> ExpensesCategory { get; set; } =
            new List<ExpenseCategory>();
        public List<IncomeCategory> IncomeCategories { get; set; } = 
            new List<IncomeCategory>();
    }
}
