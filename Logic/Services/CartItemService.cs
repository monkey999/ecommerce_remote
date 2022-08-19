using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class CartItemService : ICartItemService
    {

        //private readonly IGenericRepository<CartItem> _cartItemRepository;
        private readonly IUnitOfWork _uow;

        public CartItemService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void CreateCartItem(CartItem cartItem) => _uow.CartItems.Add(cartItem);

        public async Task<IEnumerable<CartItem>> GetAllCartItemsAsync() => await _uow.CartItems.GetAllCartItemsAsync();

        public async Task<CartItem> GetByIdCartItemsAsync(int id)
        {
            return await _uow.CartItems.GetByIdCartItemsAsync(id);
        }

        public async Task<IEnumerable<CartItem>> GetCartItemsByConditionAsync(Expression<Func<CartItem, bool>> expression)
        { 
            return await _uow.CartItems.GetCartItemsByConditionAsync(expression); 
        }
            
        public async Task Save
    }
}
