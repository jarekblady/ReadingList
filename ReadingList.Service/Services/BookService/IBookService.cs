using ReadingList.Service.DataTransferObjects;

namespace ReadingList.Service.Services.BookService
{
    public interface IBookService
    {
        List<BookDto> GetAllBook();
        BookDto GetByIdBook(int id);
        void CreateBook(BookDto dto);
        void UpdateBook(BookDto dto);
        void DeleteBook(int id);
    }
}