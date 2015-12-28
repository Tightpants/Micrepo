using System;
using System.Collections;
using System.Collections.Generic;

namespace Micrepo
{
    public interface IUnitOfWorkConfiguration
        :IDictionary<Type, EntityConfiguration>
    {
        IRepositoryProviderConfiguration SetProvider<TRepositoryProvider>(TRepositoryProvider provider)
            where TRepositoryProvider :
                class, IRepositoryProvider;


        IRepositoryProviderConfiguration SetProvider<TRepositoryProvider>() where TRepositoryProvider :
            class, IRepositoryProvider, new();
    }
}