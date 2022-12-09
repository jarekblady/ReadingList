using AutoMapper;
using ReadingList.Service.DataTransferObjects;
using ReadingList.Repository.Entities;

namespace ReadingList.Service.MappingProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(m => m.CategoryName, c => c.MapFrom(s => s.Category.Name));
            CreateMap<BookDto, Book>();
        }
    }
}