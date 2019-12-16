using DeepBlue.Domain.Contracts.Repositories;
using DeepBlue.Infraestructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DeepBlue.Infraestructure.Data.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class
    {
        protected readonly DataContext context;

        public BaseRepository(DataContext context)
        {
            this.context = context;
        }

        public void Insert(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Added;
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public IEnumerable<TEntity> FindAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        {
            return context.Set<TEntity>().AsNoTracking().Where(expression);
        }

        public TEntity FindById(TKey id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
