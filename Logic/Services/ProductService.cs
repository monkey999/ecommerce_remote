using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _productRepository;

        public ProductService(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<bool> CreateProductAsync(Product product)
        {
            await _productRepository.AddAsync(product);
            var created = await _productRepository.SaveChangesAsyncWithResult();

            return created > 0;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productRepository.FindAll()
                            .OrderBy(u => u.Id)
                                .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _productRepository.FindByCondition(u => u.Id.Equals(productId))
                            .SingleOrDefaultAsync();
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            _productRepository.Update(product);

            var updated = await _productRepository.SaveChangesAsyncWithResult();

            return updated > 0;
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            var product = await GetProductByIdAsync(productId);

            if (product == null)
                return false;

            _productRepository.RemoveById(productId);

            var deleted = await _productRepository.SaveChangesAsyncWithResult();

            return deleted > 0;
        }
    }
}
