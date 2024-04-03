using MoneyTrackerAPI.Entities;

namespace MoneyTrackerAPI.Services.OperationServices
{
    public interface IOperationRepository
    {
        Task<IEnumerable<Operation>> GetOperationsAsync();
        Task<Operation?> GetOperationAsync(int opId);
        void AddOperation(Operation operation);
        void DeleteOperation(Operation operation);
        Task<bool> SaveChangesAsync();
    }
}
