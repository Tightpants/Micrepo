using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Micrepo;

namespace Micrepo
{
    public abstract class UnitOfWork :
        IUnitOfWork
    {
        private IUnitOfWorkConfiguration _configuration;
        protected UnitOfWork()
        {

        }

        public IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class, IEntity
        {
            EnsureConfiguraton();

            var type = typeof (TEntity);
            return _configuration[type].Repository<TEntity>();
        }


        protected virtual void EnsureConfiguraton()
        {
            if (_configuration != null)
                return;

            _configuration = new UnitOfWorkConfiguration();
            Configure(_configuration);
        }


        public abstract void Configure(IUnitOfWorkConfiguration configuration);
        public void Commit()
        {
            throw new NotImplementedException();
        }
    }



    public sealed class UnitOfWorkConfiguration
        : Dictionary<Type, EntityConfiguration>,
        IUnitOfWorkConfiguration
    {
        public IRepositoryProviderConfiguration SetProvider<TRepositoryProvider>(TRepositoryProvider repositoryProvider)
            where TRepositoryProvider : class,
            IRepositoryProvider
        {
            return new RepositoryProviderConfiguration(this, repositoryProvider);
        }

        public IRepositoryProviderConfiguration SetProvider<TRepositoryProvider>() where TRepositoryProvider :
            class, IRepositoryProvider, new()
        {
            return SetProvider(new TRepositoryProvider());
        }
    }

    public sealed class RepositoryProviderConfiguration
        : IRepositoryProviderConfiguration
    {
        private readonly Dictionary<Type, EntityConfiguration> _entityConfigurations;
        private readonly IRepositoryProvider _repositoryProvider;

        internal RepositoryProviderConfiguration(
            Dictionary<Type, EntityConfiguration> entityConfigurations,
            IRepositoryProvider repositoryProvider)
        {
            _entityConfigurations = entityConfigurations;
            _repositoryProvider = repositoryProvider;
        }


        public IRepositoryProviderConfiguration For<TEntity>()
            where TEntity
            : class, IEntity
        {
            _entityConfigurations[typeof (TEntity)] =
                new EntityConfiguration(_repositoryProvider);

            return this;
        }
    }

}