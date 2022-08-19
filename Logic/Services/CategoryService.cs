using DataAccess;
using Domain;
using System.Collections.Generic;

namespace Logic.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _categoryRepository;

        public CategoryService(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void CreateCategory(Category category) => _categoryRepository.Add(category);

        public IEnumerable<Category> GetCategories() => _categoryRepository.FindAll();
    }
}
