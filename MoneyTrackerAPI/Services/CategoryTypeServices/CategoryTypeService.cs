using Microsoft.EntityFrameworkCore;
using MoneyTrackerAPI.Context;
using MoneyTrackerAPI.Entities;

namespace MoneyTrackerAPI.Services.CategoryTypeServices
{
    public class CategoryTypeService : ICategoryTypeRepository
    {
        private readonly MoneyTrackerContext _context;

        public CategoryTypeService(MoneyTrackerContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<CategoryType>> GetCategoryTypesAsync()
        {
            return await _context.CategoryTypes
                .OrderBy(ct => ct.TypeName)
                .ToListAsync();
        }

        public async Task<CategoryType?> GetCategoryTypeAsync(int catTypeId)
        {
            return await _context.CategoryTypes
                .Where(ct => ct.Id == catTypeId)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> CategoryExistsAsync(int catTypeId)
        {
            return await _context.CategoryTypes.AnyAsync(ct => ct.Id == catTypeId);
        }

        public void AddCategoryType(CategoryType categoryType)
        {
            _context.CategoryTypes.Add(categoryType);
        }

        public void DeleteCategoryType(CategoryType categoryType)
        {
            _context.CategoryTypes.Remove(categoryType);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
