using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DeepBlue.Domain.Contracts.Repositories
{
    public interface IBaseRepository<TEntity, TKey> : IDisposable where TEntity : class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> FindAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
        TEntity FindById(TKey id);

    }
}
