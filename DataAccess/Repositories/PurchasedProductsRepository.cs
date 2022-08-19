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
    public class PurchasedProductsRepository : GenericRepository<PurchasedProduct>, IPurchasedProductsRepository
    {
        public PurchasedProductsRepository(ECommerce_WebsiteContext context) : base(context)
        {

        }

        public async Task<IEnumerable<PurchasedProduct>> GetAllPurchasedProductsAsync()
        {
            return await FindAll().ToListAsync();

        }

        public async Task<PurchasedProduct> GetByIdPurchasedProductsAsync(int id)
        {
            return await FindByCondition(p => p.Id.Equals(id))
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PurchasedProduct>> GetPurchasedProductsByConditionAsync(Expression<Func<PurchasedProduct, bool>> expression)
        {
            return await FindByCondition(expression).ToListAsync();

        }
    }
}
