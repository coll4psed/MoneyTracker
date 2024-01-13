using Microsoft.EntityFrameworkCore;
using MoneyTrackerAPI.Contexts;
using MoneyTrackerAPI.Entities;

namespace MoneyTrackerAPI.Services.CategoryServices
{
    public class CategoryService : ICategoryRepository
    {
        private readonly MoneyTrackerContext _context;

        public CategoryService(MoneyTrackerContext context)
        {
            _context = context ?? 
                throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToListAsync();
        }

        public async Task<Category?> GetCategoryAsync(int catId)
        {
            return await _context.Categories
                .Where(c => c.Id == catId)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> CategoryExistsAsync(int catId)
        {
            return await _context.Categories.AnyAsync(c => c.Id == catId);
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
        }

        public void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
