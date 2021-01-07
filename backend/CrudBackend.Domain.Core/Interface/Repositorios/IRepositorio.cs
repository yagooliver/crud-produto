using CrudBackend.Domain.Core.Shared.EntityBase;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CrudBackend.Domain.Core.Interface.Repositorios
{
    public interface IRepositorio<T> where T : EntityBase
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        IQueryable<T> GetAll();
        IQueryable<T> GetByExpression(Expression<Func<T, bool>> predicate);
        T GetById(Guid id);
    }
}
