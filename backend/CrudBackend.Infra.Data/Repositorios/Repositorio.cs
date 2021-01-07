using CrudBackend.Domain.Core.Interface.Repositorios;
using CrudBackend.Domain.Core.Shared.EntityBase;
using CrudBackend.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CrudBackend.Infra.Data.Repositorios
{
    public class Repositorio<T> : IRepositorio<T> where T : EntityBase
    {
        protected readonly CrudContext _db;
        protected readonly DbSet<T> _entry;

        public Repositorio(CrudContext db)
        {
            _db = db;
            _entry = _db.Set<T>();
        }

        public void Add(T entity)
        {
            _entry.Add(entity);
        }

        public virtual IQueryable<T> GetAll() => _entry;

        public virtual IQueryable<T> GetByExpression(Expression<Func<T, bool>> predicate) => _entry.Where(predicate);

        public virtual T GetById(Guid id) => _entry.Find(id);

        public virtual void Remove(T entity) => _entry.Remove(entity);

        public virtual void Update(T entity) => _entry.Update(entity);
    }
}
