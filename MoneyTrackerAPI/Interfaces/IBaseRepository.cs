using Microsoft.EntityFrameworkCore.ChangeTracking;
using MoneyTrackerAPI.Models.Interfaces;

namespace MoneyTrackerAPI.Interfaces
{
    public interface IBaseRepository
    {
        Task<IEnumerable<T>> GetAll<T>() where T : class, IEntity;
        Task<T> Get<T>(int id) where T : class, IEntity;
        Task<EntityEntry<T>> Create<T>(T item) where T : class, IEntity;
        Task<EntityEntry<T>> Update<T>(T item, int id) where T : class, IEntity;
        Task<bool> Delete<T>(int id) where T : class, IEntity;
        Task SaveAsync();
    }
}
