using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoeStore.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ShoeStoreContext _storeContext;
        private readonly DbSet<T> _dbSet;
        public Repository(ShoeStoreContext storeContext)
        {
            _storeContext = storeContext;
            _dbSet = storeContext.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Delete(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public IQueryable<T> Query()
        {
            return _dbSet.AsQueryable();
        }

        public IQueryable<T> Query(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).AsQueryable();
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _storeContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
