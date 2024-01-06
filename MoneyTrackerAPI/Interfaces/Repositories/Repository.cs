using MoneyTrackerAPI.Contexts;
using MoneyTrackerAPI.Interfaces;
using MoneyTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MoneyTrackerAPI.Models.Interfaces;

namespace MoneyTrackerAPI.Interfaces.Repositries
{
    public class Repository : IBaseRepository
    {
        private readonly MoneyTrackerContext _context;

        public Repository(MoneyTrackerContext context)
        {
            _context = context ?? 
                throw new ArgumentNullException(nameof(context));
        }

        public async Task<EntityEntry<T>> Create<T>(T item) where T : class, IEntity
        {
            return await _context.Set<T>().AddAsync(item);
        }

        public async Task<bool> Delete<T>(int id) where T : class, IEntity
        {
            if (id > 0)
            {
                var oldModel = await _context.Set<T>().FirstOrDefaultAsync(o => o.Id == id);
                if (oldModel != null)
                {
                    _context.Set<T>().Remove(oldModel);
                    return true;
                }
            }

            return false;
        }

        public async Task<IEnumerable<T>> GetAll<T>() where T : class, IEntity
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> Get<T>(int id) where T : class, IEntity
        {
            return await _context.Set<T>().FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<EntityEntry<T>> Update<T>(T item, int id) where T : class, IEntity
        {
            if (id > 0)
            {
                var oldModel = await _context.Set<T>().FirstOrDefaultAsync(o => o.Id == id);
                if (oldModel != null)
                {
                    item.Id = id;
                    _context.Set<T>().Update(item);
                }
            }

            return null;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
