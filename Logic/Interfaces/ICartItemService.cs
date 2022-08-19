using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Logic.Services
{
    public interface ICartItemService
    {
        void CreateCartItem(CartItem cartItem);
        Task<IEnumerable<CartItem>> GetAllCartItemsAsync();
        Task<CartItem> GetByIdCartItemsAsync(int id);
        Task<IEnumerable<CartItem>> GetCartItemsByConditionAsync(Expression<Func<CartItem, bool>> expression);
        Task SaveAsync();
    }
}