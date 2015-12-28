using System;

namespace Micrepo
{
    public interface IRepositoryProvider :
        IObserver<UnitOfWork>
    {
            IRepository<TEntity> ConstructRepository<TEntity>()
            where TEntity : class, IEntity;

        void Rollback();

        bool Commit(Guid transactionKey);
    }
}