using Microsoft.EntityFrameworkCore.ChangeTracking;
using MoneyTrackerAPI.Models;

namespace MoneyTrackerAPI.Interfaces
{
    public interface IAccountRepository
    {
        Task<EntityEntry<Account>> Create(Account item);
        Task<EntityEntry<Account>> Update(Account item);
        Task<bool> Delete<T>(int id);
        Task<IEnumerable<Account>> GetAll();
        Task<Account> Get(int id);
    }
}
