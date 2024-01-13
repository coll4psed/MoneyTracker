using MoneyTrackerAPI.Entities;

namespace MoneyTrackerAPI.Services.AccountServices
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAccountsAsync();
        Task<Account?> GetAccountAsync(int accId);
        Task<bool> AccountExistsAsync(int accId);
        void AddAccount(Account account);
        void DeleteAccount(Account account);
        Task<bool> SaveChangesAsync();
    }
}
