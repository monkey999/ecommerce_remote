using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByConditionAsync(Expression<Func<Product, bool>> expression);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetByIdProductsAsync(int id);
    }
}
