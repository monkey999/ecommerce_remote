﻿using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.Services
{
    public interface ICategoryService
    {
        Task<bool> CreateCategoryAsync(Category category);
        Task<Category> GetCategoryByIdAsync(int categoryId);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<bool> UpdateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(int categoryId);
    }
}