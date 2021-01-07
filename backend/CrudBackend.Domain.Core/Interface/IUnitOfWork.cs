using System;

namespace CrudBackend.Domain.Core.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
