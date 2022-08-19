using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.Services
{
    public interface IProductService
    {
        void CreateProduct(Product product);
        Task<IEnumerable<Product>> GetProducts();
    }
}