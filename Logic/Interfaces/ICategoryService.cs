using Domain;
using System.Collections.Generic;

namespace Logic.Services
{
    public interface ICategoryService
    {
        void CreateCategory(Category category);
        IEnumerable<Category> GetCategories();
    }
}