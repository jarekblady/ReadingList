using AutoMapper;
using ReadingList.API.DataTransferObjects;
using ReadingList.API.Entities;
using ReadingList.API.Repositories.BookRepository;

namespace ReadingList.API.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }


        public List<BookDto> GetAllBook()
        {
            var books = _bookRepository.GetAllBook();
            var result = _mapper.Map<List<BookDto>>(books);
            return result;
        }

        public BookDto GetByIdBook(int id)
        {
            var book = _bookRepository.GetByIdBook(id);
            var result = _mapper.Map<BookDto>(book);
            return result;
        }


        public void CreateBook(BookDto dto)
        {
            var book = new Book()
            {
                Title = dto.Title,
                Author = dto.Author,
                IsRead = dto.IsRead,
                CategoryId = dto.CategoryId,
            };
            _bookRepository.CreateBook(book);
        }

        public void UpdateBook(BookDto dto)
        {
            var book = new Book()
            {
                Id = dto.Id,
                Title = dto.Title,
                Author = dto.Author,
                IsRead = dto.IsRead,
                CategoryId = dto.CategoryId,
            };
            _bookRepository.UpdateBook(book);
        }

        public void DeleteBook(int id)
        {
            var book = _bookRepository.GetByIdBook(id);
            _bookRepository.DeleteBook(book);
        }


    }
}
