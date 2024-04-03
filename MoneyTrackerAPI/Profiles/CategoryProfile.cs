using AutoMapper;

namespace MoneyTrackerAPI.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Entities.Category, Models.Category.CategoryDto>();
            CreateMap<Models.Category.CategoryForCreationDto, Entities.Category>();
            CreateMap<Models.Category.CategoryForUpdateDto, Entities.Category>();
            CreateMap<Entities.Category, Models.Category.CategoryForUpdateDto>();
        }
    }
}
