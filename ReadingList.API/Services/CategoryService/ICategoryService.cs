﻿using ReadingList.API.DataTransferObjects;

namespace ReadingList.API.Services.CategoryService
{
    public interface ICategoryService
    {
        List<CategoryDto> GetAllCategory();
        CategoryDto GetByIdCategory(int id);
        void CreateCategory(CategoryDto dto);
        void UpdateCategory(CategoryDto dto);
        void DeleteCategory(int id);
    }
}