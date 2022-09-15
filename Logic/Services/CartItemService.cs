using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly IGenericRepository<CartItem> _cartItemRepository;

        public CartItemService(IGenericRepository<CartItem> cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<bool> CreateCartItem(CartItem cartItem)
        {
            await _cartItemRepository.AddAsync(cartItem);
            var created = await _cartItemRepository.SaveChangesAsyncWithResult();

            return created > 0;
        }

        public async Task<CartItem> GetCartItemByIdAsync(int cartItemId)
        {
            return await _cartItemRepository.FindByCondition(x => x.Id.Equals(cartItemId)).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CartItem>> GetAllCartItemsAsync()
        {
            return await _cartItemRepository.FindAll().OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<bool> UpdateCartItemAsync(CartItem cartItem)
        {
            _cartItemRepository.Update(cartItem);
            var updated = await _cartItemRepository.SaveChangesAsyncWithResult();

            return updated > 0;
        }

        public async Task<bool> DeleteCartItemAsync(int cartItemId)
        {
            var user = await GetCartItemByIdAsync(cartItemId);

            if (user == null)
                return false;

            _cartItemRepository.RemoveById(cartItemId);
            var deleted = await _cartItemRepository.SaveChangesAsyncWithResult();

            return deleted > 0;
        }
    }
}
