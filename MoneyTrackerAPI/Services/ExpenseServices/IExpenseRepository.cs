using MoneyTrackerAPI.Entities;

namespace MoneyTrackerAPI.Services.ExpenseServices
{
    public interface IExpenseRepository
    {
        Task<IEnumerable<Expense>> GetExpensesAsync();
        Task<Expense?> GetExpenseAsync(int expId);
        void AddExpense(Expense expense);
        void DeleteExpense(Expense expense);
        Task<bool> SaveChangesAsync();
    }
}
