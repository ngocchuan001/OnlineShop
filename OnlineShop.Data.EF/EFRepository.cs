using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Entities;
using OnlineShop.Infrastructure.Interfaces;
using OnlineShop.Infrastructure.SharedKernel;

namespace OnlineShop.Data.EF
{
    public class EFRepository<T,K> : IRepository<T,K>, IDisposable where T : DomainEntity<K>
    {
        private readonly AppDbContext _dbContext;

        public EFRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T FindById(K id, params Expression<Func<T, object>>[] includeProperties)
        {
            T item = FindAll(n => n.Id.Equals(id), includeProperties).SingleOrDefault();
            return item;
        }

        public T FindSingle(Expression<Func<T, bool>> conditions, params Expression<Func<T, object>>[] includeProperties)
        {
            T item = FindAll(conditions, includeProperties).SingleOrDefault();
            return item;
        }

        public IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _dbContext.Set<T>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items;
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> conditions, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _dbContext.Set<T>().Where(conditions);
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items;
        }

        public void Add(T entity)
        {
            _dbContext.Add(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Update(entity);
        }

        public void Remove(T entity)
        {
            _dbContext.Remove(entity);
        }

        public void Remove(K id)
        {
            _dbContext.Remove(FindById(id));
        }

        public void RemoveMultiple(List<T> entities)
        {
            _dbContext.RemoveRange(entities);
        }

        public void Dispose()
        {
            if(_dbContext != null) _dbContext.Dispose();
        }
    }
}