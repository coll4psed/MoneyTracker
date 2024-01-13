using MoneyTrackerAPI.Entities;

namespace MoneyTrackerAPI.Services.IncomeServices
{
    public interface IIncomeRepository
    {
        Task<IEnumerable<Income>> GetIncomesAsync();
        Task<Income?> GetIncomeAsync(int incId);
        void AddIncome(Income income);
        void DeleteIncome(Income income);
        Task<bool> SaveChangesAsync();
    }
}
