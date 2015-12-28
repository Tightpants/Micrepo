using System;

namespace Micrepo
{
    public sealed class Repository<TEntity> :
        IRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly IRepository<TEntity> _repository;
        

        public Repository(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public TEntity Get(Guid guid)
        {
            return _repository.Get(guid);
        }

        public bool Add(TEntity entity)
        {
            return _repository.Add(entity);
        }

        public bool Update(TEntity entity)
        {
            return _repository.Update(entity);
        }

        public bool Delete(TEntity entity)
        {
            return _repository.Delete(entity);
        }

    }
}