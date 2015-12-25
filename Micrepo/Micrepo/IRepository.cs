using System;

namespace Micrepo
{
    public interface IRepository<TEntity>
        where TEntity :
        class,
        IEntity
    {
        TEntity Get(Guid guid);

        bool Add(TEntity entity);

        bool Update(TEntity entity);

        bool Delete(TEntity entity);
    }
}
