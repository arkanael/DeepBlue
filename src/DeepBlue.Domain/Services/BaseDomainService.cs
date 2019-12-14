using DeepBlue.Domain.Contracts.Repositories;
using DeepBlue.Domain.Contracts.Services;
using System.Collections.Generic;

namespace DeepBlue.Domain.Services
{
    public abstract class BaseDomainService<TEntity, Tkey> : IBaseDomainService<TEntity, Tkey> where TEntity : class
    {
        protected readonly IBaseRepository<TEntity, Tkey> repository;

        protected BaseDomainService(IBaseRepository<TEntity, Tkey> repository)
        {
            this.repository = repository;
        }

        public virtual void Create(TEntity entity)
        {
            repository.Insert(entity);
        }

        public virtual void Update(TEntity entity)
        {
            repository.Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            repository.Delete(entity);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return repository.FindAll();
        }

        public virtual TEntity GetId(Tkey id)
        {
            return repository.FindById(id);
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
