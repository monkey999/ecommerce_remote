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
    public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(ECommerce_WebsiteContext context) : base(context)
        {

        }

        public async Task<IEnumerable<CartItem>> GetAllCartItemsAsync()
        {
            return await FindAll().OrderBy(ci=>ci.Quantity).ToListAsync();
        }

        public async Task<CartItem> GetByIdCartItemsAsync(int id)
        {
            return await FindByCondition(ci => ci.Id.Equals(id))
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CartItem>> GetCartItemsByConditionAsync(Expression<Func<CartItem, bool>> expression)
        {
            return await FindByCondition(expression).ToListAsync();
        }


    }
}
