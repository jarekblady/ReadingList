using AutoMapper;
using ReadingList.API.DataTransferObjects;
using ReadingList.API.Entities;

namespace ReadingList.API.MappingProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
        }
    }
}
