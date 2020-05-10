using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ShoeStore.Data
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        List<T> GetAll();
        T Get(int id);
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);
        IQueryable<T> Query();
        IQueryable<T> Query(Expression<Func<T, bool>> expression); 
    }
}
