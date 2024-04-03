using Microsoft.EntityFrameworkCore;
using MoneyTrackerAPI.Context;
using MoneyTrackerAPI.Entities;

namespace MoneyTrackerAPI.Services.OperationServices
{
    public class OperationService : IOperationRepository
    {
        private readonly MoneyTrackerContext _context;

        public OperationService(MoneyTrackerContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Operation>> GetOperationsAsync()
        {
            return await _context.Operations
                .OrderBy(o => o.Date)
                .ToListAsync();
        }

        public async Task<Operation?> GetOperationAsync(int opId)
        {
            return await _context.Operations
                .Where(o => o.Id == opId)
                .FirstOrDefaultAsync();
        }

        public void AddOperation(Operation operation)
        {
            _context.Operations.Add(operation);
        }

        public void DeleteOperation(Operation operation)
        {
            _context.Operations.Remove(operation);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
