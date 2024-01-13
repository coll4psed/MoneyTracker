using Microsoft.EntityFrameworkCore;
using MoneyTrackerAPI.Contexts;
using MoneyTrackerAPI.Entities;

namespace MoneyTrackerAPI.Services.AccountServices
{
    public class AccountService : IAccountRepository
    {
        private readonly MoneyTrackerContext _context;

        public AccountService(MoneyTrackerContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Account>> GetAccountsAsync()
        {
            return await _context.Accounts.OrderBy(a => a.AccountName).ToListAsync();
        }

        public async Task<Account?> GetAccountAsync(int accId)
        {
            return await _context.Accounts
                .Where(a => a.Id == accId)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> AccountExistsAsync(int accId)
        {
            return await _context.Accounts.AnyAsync(a => a.Id == accId);
        }

        public void AddAccount(Account account)
        {
            _context.Accounts.Add(account);
        }

        public void DeleteAccount(Account account)
        {
            _context.Accounts.Remove(account);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
