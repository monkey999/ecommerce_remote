using DataAccess;
using Domain;
using System.Collections.Generic;
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

        public void CreateProduct(Product product) => _productRepository.AddAsync(product);

        public IEnumerable<Product> GetProducts() => _productRepository.FindAll();

        Task<IEnumerable<Product>> IProductService.GetProducts()
        {
            throw new System.NotImplementedException();
        }
    }
}
