using ReadingList.API.Entities;

namespace ReadingList.API.Repositories.BookRepository
{
    public interface IBookRepository
    {
        List<Book> GetAllBook();
        Book GetByIdBook(int id);
        void CreateBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);
    }
}