using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ECommerce_WebsiteContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(ECommerce_WebsiteContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }


        public async IQueryable<T> FindAll() => _dbSet.AsNoTracking();

        public async Task<IQueryable<T>> FindByCondition(Expression<Func<T, bool>> expression) => await _dbSet.Where(expression).AsNoTracking();
        public void Dispose() => _context.Dispose();
        public async Task Save() => await _context.SaveChangesAsync();

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            await Save();
        }

        public async Task AddRange(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await Save();
        }

        public async Task RemoveById(int id)
        {
            _dbSet.Remove(_dbSet.Find(id));
            await Save();
        }

        public async Task RemoveByEntity(T entity)
        {
            _dbSet.Remove(entity);
            await Save();
        }

        public async Task RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            await Save();
        }

        public async Task Update(T entity)
        {
            _dbSet.Update(entity);
            await Save();
        }


    }
}
