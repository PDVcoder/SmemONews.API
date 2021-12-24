using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SmemONews.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Expression<Func<T, Boolean>> predicate);
        IEnumerable<T> FindWithIncludes(params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> FindWithIncludes(Expression<Func<T, Boolean>> predicate , params Expression<Func<T, object>>[] includeProperties);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        int Count();
        int Count(Expression<Func<T, Boolean>> predicate);
    }
}
