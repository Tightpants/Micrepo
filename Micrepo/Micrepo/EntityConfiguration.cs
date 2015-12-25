namespace Micrepo
{
    internal class EntityConfiguration

    {
        private readonly IRepositoryProvider _repositoryProvider;

        public EntityConfiguration(IRepositoryProvider repositoryProvider)
        {
            _repositoryProvider = repositoryProvider;
        }

        public IRepository<TEntity> Repository<TEntity>()
            where TEntity : class, IEntity

        {
            var wrappedRepository = _repositoryProvider.ConstructRepository<TEntity>();

            return new Repository<TEntity>(wrappedRepository);
        }

    }
}