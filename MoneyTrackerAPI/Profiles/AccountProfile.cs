using AutoMapper;

namespace MoneyTrackerAPI.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Entities.Account, Models.Account.AccountDto>();
            CreateMap<Models.Account.AccountForCreationDto, Entities.Account>();
            CreateMap<Models.Account.AccountForUpdateDto, Entities.Account>();
            CreateMap<Entities.Account, Models.Account.AccountForUpdateDto>();
        }
    }
}
