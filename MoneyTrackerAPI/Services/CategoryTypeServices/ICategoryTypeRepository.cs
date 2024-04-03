using MoneyTrackerAPI.Entities;

namespace MoneyTrackerAPI.Services.CategoryTypeServices
{
    public interface ICategoryTypeRepository
    {
        Task<IEnumerable<CategoryType>> GetCategoryTypesAsync();
        Task<CategoryType?> GetCategoryTypeAsync(int catTypeId);
        Task<bool> CategoryExistsAsync(int catTypeId);
        void AddCategoryType(CategoryType categoryType);
        void DeleteCategoryType(CategoryType categoryType);
        Task<bool> SaveChangesAsync();
    }
}
