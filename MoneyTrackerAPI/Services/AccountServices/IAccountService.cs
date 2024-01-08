using MoneyTrackerAPI.Models;

namespace MoneyTrackerAPI.Services.AccountServices
{
    public interface IAccountService
    {
        IEnumerable<Account> Get();
    }
}
