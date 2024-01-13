using Microsoft.EntityFrameworkCore;
using MoneyTrackerAPI.Contexts;
using MoneyTrackerAPI.Entities;

namespace MoneyTrackerAPI.Services.ExpenseServices
{
    public class ExpenseService : IExpenseRepository
    {
        private readonly MoneyTrackerContext _context;

        public ExpenseService(MoneyTrackerContext context)
        {
            _context = context ?? 
                throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Expense>> GetExpensesAsync()
        {
            return await _context.Expenses
                .OrderBy(e => e.ExpenseDate)
                .ToListAsync();
        }

        public async Task<Expense?> GetExpenseAsync(int expId)
        {
            return await _context.Expenses
                .Where(e => e.Id == expId)
                .FirstOrDefaultAsync();
        }

        public void AddExpense(Expense expense)
        {
            _context.Expenses.Add(expense);
        }

        public void DeleteExpense(Expense expense)
        {
            _context.Expenses.Remove(expense);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
