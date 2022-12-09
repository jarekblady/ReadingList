using AutoMapper;
using ReadingList.Service.DataTransferObjects;
using ReadingList.Repository.Entities;

namespace ReadingList.Service.MappingProfiles
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
