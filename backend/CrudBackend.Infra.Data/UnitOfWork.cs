using CrudBackend.Domain.Core.Interface;
using CrudBackend.Infra.Data.Context;
using System;

namespace CrudBackend.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CrudContext _context;

        public UnitOfWork(CrudContext context)
        {
            _context = context;
        }

        public bool Commit() => _context.SaveChanges() > 0;

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
