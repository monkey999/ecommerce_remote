using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        IQueryable<T> FindAll();
        void RemoveById(int id);
        void RemoveRange(IEnumerable<T> entities);
        void Update(T entity);
        Task<int> SaveChangesAsyncWithResult();
        Task SaveChangesAsync();
        void Dispose();
    }
}