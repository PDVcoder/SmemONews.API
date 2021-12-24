using Microsoft.EntityFrameworkCore;
using SmemONews.DAL.EF;
using SmemONews.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SmemONews.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DataContext _db;
        private DbSet<T> _set;

        public Repository(DataContext dataContext)
        {
            _db = dataContext;
            _set = _db.Set<T>();
        }

        public void Create(T item)
        {
            _set.Add(item);
        }

        public void Delete(int id)
        {
            T item = _set.Find(id);
            _set.Remove(item);
        }

        public IEnumerable<T> Find(Expression<Func<T, Boolean>> predicate)
        {
            return _set.Where(predicate).ToList();
        }

        public IEnumerable<T> FindWithIncludes(params Expression<Func<T, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<T> FindWithIncludes(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> quary = Include(includeProperties);
            return quary.Where(predicate).ToList();
        }

        public T Get(int id)
        {
            return _set.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _set;
        }

        public void Update(T item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public int Count()
        {
            return _set.Count();
        }

        public int Count(Expression<Func<T, Boolean>> predicate)
        {
            return _set.Count(predicate);
        }

        private IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _set.AsNoTracking();
            return includeProperties.Aggregate(query, (current, includeProperties) => current.Include(includeProperties));
        }
    }
}
