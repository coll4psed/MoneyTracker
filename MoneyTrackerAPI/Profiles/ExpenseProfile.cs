using AutoMapper;

namespace MoneyTrackerAPI.Profiles
{
    public class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            CreateMap<Entities.Expense, Models.Expense.ExpenseDto>();
            CreateMap<Models.Expense.ExpenseForCreationDto, Entities.Expense>();
            CreateMap<Models.Expense.ExpenseForUpdateDto, Entities.Expense>();
            CreateMap<Entities.Expense, Models.Expense.ExpenseForUpdateDto>();
        }
    }
}
