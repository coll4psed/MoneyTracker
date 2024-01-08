using MoneyTrackerAPI.Models;

namespace MoneyTrackerAPI.Services.AccountServices
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAccountsAsync();
        Task<Account?> GetAccountAsync(int accId);
        Task<bool> AccountExistsAsync(int accId);
        Task AddAccount(Account account);
        Task<bool> SaveChangesAsync();
    }
}
