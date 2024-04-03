using AutoMapper;

namespace MoneyTrackerAPI.Profiles
{
    public class OperationProfile : Profile
    {
        public OperationProfile()
        {
            CreateMap<Entities.Operation, Models.Operation.OperationDto>();
            CreateMap<Models.Operation.OperationForCreationDto, Entities.Operation>();
            CreateMap<Models.Operation.OperationForUpdateDto, Entities.Operation>();
            CreateMap<Entities.Operation, Models.Operation.OperationForUpdateDto>();
        }
    }
}
