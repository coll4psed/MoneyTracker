using MoneyTrackerAPI.Entities;

namespace MoneyTrackerAPI.Services.CategoryServices
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category?> GetCategoryAsync(int catId);
        Task<bool> CategoryExistsAsync(int catId);
        void AddCategory(Category category);
        void DeleteCategory(Category category);
        Task<bool> SaveChangesAsync();
    }
}
