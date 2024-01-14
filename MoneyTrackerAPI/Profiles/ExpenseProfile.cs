using AutoMapper;

namespace MoneyTrackerAPI.Profiles
{
    public class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            CreateMap<Entities.Expense, Models.Expense.ExpenseDto>();
        }
    }
}
