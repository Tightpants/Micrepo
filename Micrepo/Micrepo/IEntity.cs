using System;

namespace Micrepo
{
    public interface IEntity
    {
        Guid Key { get; set; }
    }
}