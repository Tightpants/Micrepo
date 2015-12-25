namespace Micrepo
{
    public interface IUnitOfWorkConfiguration
    {
        IRepositoryProviderConfiguration SetProvider<TRepositoryProvider>()
            where TRepositoryProvider : class, IRepositoryProvider;
    }
}