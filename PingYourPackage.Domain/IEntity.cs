using System;

namespace PingYougPackage.Domain
{
    public interface IEntity
    {
        Guid Key { get; set; }
    }
}
