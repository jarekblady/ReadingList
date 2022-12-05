using Microsoft.EntityFrameworkCore;
using ReadingList.API.Entities;

namespace ReadingList.API.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BookDbContext _context;

        public CategoryRepository(BookDbContext context)
        {
            _context = context;
        }

        public List<Category> GetAllCategory()
        {

            return _context.Categories.Include(c => c.Books).ToList();
        }

        public Category GetByIdCategory(int id)
        {
            return _context.Categories.Include(c => c.Books).FirstOrDefault(c => c.Id == id);
        }

        public void CreateCategory(Category category)
        {

            _context.Categories.Add(category);
            _context.SaveChanges();

        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();

        }
        public void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);

            _context.SaveChanges();

        }
    }
}
