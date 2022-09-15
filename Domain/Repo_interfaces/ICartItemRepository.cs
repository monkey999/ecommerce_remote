using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
    }
}
