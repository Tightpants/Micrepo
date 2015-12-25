using System;
using System.Collections.Generic;

namespace Micrepo
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<Type, EntityConfiguration> _entityConfigurations;

        protected UnitOfWork()
        {
            _entityConfigurations = new Dictionary<Type, EntityConfiguration>();
        }

        public IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class, IEntity
        {
            var type = typeof (TEntity);
            return _entityConfigurations[type].Repository<TEntity>();
        }

        public abstract void Configure(IUnitOfWorkConfiguration configuration);

        public void Commit()
        {
            throw new NotImplementedException();
        }
    }
}