using AutoMapper;
using ReadingList.Service.DataTransferObjects;
using ReadingList.Repository.Entities;
using ReadingList.Repository.Repositories.CategoryRepository;

namespace ReadingList.Service.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }


        public List<CategoryDto> GetAllCategory()
        {
            var categories = _categoryRepository.GetAllCategory();
            var result = _mapper.Map<List<CategoryDto>>(categories);
            return result;
        }

        public CategoryDto GetByIdCategory(int id)
        {
            var category = _categoryRepository.GetByIdCategory(id);
            var result = _mapper.Map<CategoryDto>(category);
            return result;
        }


        public void CreateCategory(CategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            _categoryRepository.CreateCategory(category);
        }

        public void UpdateCategory(CategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            _categoryRepository.UpdateCategory(category);
        }

        public void DeleteCategory(int id)
        {
            var category = _categoryRepository.GetByIdCategory(id);
            _categoryRepository.DeleteCategory(category);
        }


    }
}
