using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPurchasedProductsRepository : IGenericRepository<PurchasedProduct>
    {
        Task<IEnumerable<PurchasedProduct>> GetPurchasedProductsByConditionAsync(Expression<Func<PurchasedProduct, bool>> expression);
        Task<IEnumerable<PurchasedProduct>> GetAllPurchasedProductsAsync();
        Task<PurchasedProduct> GetByIdPurchasedProductsAsync(int id);

    }
}
