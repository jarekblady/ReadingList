using AutoMapper;
using ReadingList.API.DataTransferObjects;
using ReadingList.API.Entities;

namespace ReadingList.API.MappingProfiles
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