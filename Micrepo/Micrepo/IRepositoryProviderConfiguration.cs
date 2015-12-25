namespace Micrepo
{
    public interface IRepositoryProviderConfiguration
    {
        IRepositoryProviderConfiguration For<TEntity>()
            where TEntity : class, IEntity;
    }
}