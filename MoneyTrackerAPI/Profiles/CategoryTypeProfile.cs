using AutoMapper;

namespace MoneyTrackerAPI.Profiles
{
    public class CategoryTypeProfile : Profile
    {
        public CategoryTypeProfile()
        {
            CreateMap<Entities.CategoryType, Models.CategoryType.CategoryTypeDto>();
            CreateMap<Models.CategoryType.CategoryTypeForCreationDto, Entities.CategoryType>();
            CreateMap<Models.CategoryType.CategoryTypeForUpdateDto, Entities.CategoryType>();
            CreateMap<Entities.CategoryType, Models.CategoryType.CategoryTypeForUpdateDto>();
        }
    }
}
