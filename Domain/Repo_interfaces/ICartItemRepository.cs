using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
        Task<IEnumerable<CartItem>> GetCartItemsByConditionAsync(Expression<Func<CartItem, bool>> expression);
        Task<IEnumerable<CartItem>> GetAllCartItemsAsync();
        Task<CartItem> GetByIdCartItemsAsync(int id);
       
    }
}
