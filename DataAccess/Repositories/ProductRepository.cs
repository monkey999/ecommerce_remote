using Domain;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ECommerce_WebsiteContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await FindAll().OrderBy(pr=>pr.Name).ToListAsync();
        }

        public async Task<Product> GetByIdProductsAsync(int id)
        {
            return await FindByCondition(product => product.Id.Equals(id))
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByConditionAsync(Expression<Func<Product, bool>> expression)
        {
            return await FindByCondition(expression).ToListAsync();
        }

       
    }
}
