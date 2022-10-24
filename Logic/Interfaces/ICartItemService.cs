using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.Services
{
    public interface ICartItemService
    {
        Task<bool> CreateCartItem(CartItem cartItem);
        Task<CartItem> GetCartItemByIdAsync(int cartItemId);
        Task<IEnumerable<CartItem>> GetAllCartItemsAsync();
        Task<bool> UpdateCartItemAsync(CartItem cartItem);
        Task<bool> DeleteCartItemAsync(int cartItemId);
    }
}