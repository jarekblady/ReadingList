using ReadingList.API.Entities;

namespace ReadingList.API.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategory();
        Category GetByIdCategory(int id);
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
    }
}

