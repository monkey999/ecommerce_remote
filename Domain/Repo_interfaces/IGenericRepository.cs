using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IGenericRepository<T> where T : class
    {
        Task Add(T entity);
        Task AddRange(IEnumerable<T> entities);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        IQueryable<T> FindAll();
        Task RemoveById(int id);
        Task RemoveByEntity(T entity);
        Task RemoveRange(IEnumerable<T> entities);
        Task Update(T entity);
        Task Save();
        void Dispose();
    }
}