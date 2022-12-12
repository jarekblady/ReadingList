using AutoMapper;
using ReadingList.Service.DataTransferObjects;
using ReadingList.Repository.Entities;
using ReadingList.Repository.Repositories.BookRepository;

namespace ReadingList.Service.Services.BookService
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
            var book = _mapper.Map<Book>(dto);
            _bookRepository.CreateBook(book);
        }

        public void UpdateBook(BookDto dto)
        {
            var book = _mapper.Map<Book>(dto);
            _bookRepository.UpdateBook(book);
        }

        public void DeleteBook(int id)
        {
            var book = _bookRepository.GetByIdBook(id);
            _bookRepository.DeleteBook(book);
        }

        public void UpdateIsRead(int id)
        {
            var book = _bookRepository.GetByIdBook(id);
            book.IsRead = book.IsRead ? false : true;
            _bookRepository.UpdateBook(_mapper.Map<Book>(book));
        }
    }
}
