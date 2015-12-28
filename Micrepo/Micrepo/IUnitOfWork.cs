using System;
using System.Runtime.Remoting.Messaging;

namespace Micrepo
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> GetRepository<TEntity>()
            where TEntity :
                class,
                IEntity;

        void Configure(IUnitOfWorkConfiguration configuration);

        void Commit();
    }
}