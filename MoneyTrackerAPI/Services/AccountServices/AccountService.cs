using MoneyTrackerAPI.Contexts;
using MoneyTrackerAPI.Models;

namespace MoneyTrackerAPI.Services.AccountServices
{
    public class AccountService : IAccountService
    {
        private readonly MoneyTrackerContext _context;

        public AccountService(MoneyTrackerContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Account> Get()
        {
            
        }
    }
}
