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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ECommerce_WebsiteContext context) : base(context)
        {

        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await FindAll().OrderBy(u => u.Name).ToListAsync();
        }

        public async Task<User> GetByIdUsersAsync(int id)
        {
            return await FindByCondition(u => u.Id.Equals(id))
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetUsersByConditionAsync(Expression<Func<User, bool>> expression)
        {
            return await FindByCondition(expression).ToListAsync();
        }
    }
}
