using System;

namespace Micrepo
{
    public interface IRepositoryProvider
    {
        IRepository<TEntity> ConstructRepository<TEntity>()
            where TEntity : class, IEntity;

        void Rollback();

        bool Commit(Guid transactionKey);
    }
}