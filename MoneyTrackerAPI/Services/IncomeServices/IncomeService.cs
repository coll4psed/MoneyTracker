using Microsoft.EntityFrameworkCore;
using MoneyTrackerAPI.Contexts;
using MoneyTrackerAPI.Entities;

namespace MoneyTrackerAPI.Services.IncomeServices
{
    public class IncomeService : IIncomeRepository
    {
        private readonly MoneyTrackerContext _context;

        public IncomeService(MoneyTrackerContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Income>> GetIncomesAsync()
        {
            return await _context.Incomes
                .OrderBy(e => e.IncomeDate)
                .ToListAsync();
        }

        public async Task<Income?> GetIncomeAsync(int incId)
        {
            return await _context.Incomes
                .Where(i => i.Id == incId)
                .FirstOrDefaultAsync();
        }

        public void AddIncome(Income income)
        {
            _context.Incomes.Add(income);
        }

        public void DeleteIncome(Income income)
        {
            _context.Incomes.Remove(income);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
