using Microsoft.EntityFrameworkCore;
using ReadingList.Repository.Context;
using ReadingList.Repository.Entities;

namespace ReadingList.Repository.Repositories.BookRepository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _context;

        public BookRepository(BookDbContext context)
        {
            _context = context;
        }

        public List<Book> GetAllBook()
        {

            return _context.Books.Include(b => b.Category).OrderBy(b => b.Order).ToList();
        }

        public Book GetByIdBook(int id)
        {
            return _context.Books.Include(b => b.Category).FirstOrDefault(b => b.Id == id);
        }

        public void CreateBook(Book book)
        {

            _context.Books.Add(book);
            _context.SaveChanges();

        }

        public void UpdateBook(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();

        }
        public void DeleteBook(Book book)
        {
            _context.Books.Remove(book);

            _context.SaveChanges();

        }
    }
}
