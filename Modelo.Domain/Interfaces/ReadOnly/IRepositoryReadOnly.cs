using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Modelo.Domain.Interfaces.ReadOnly
{
    public interface IRepositoryReadOnly<TEntity> : IDisposable where TEntity : class
    {
        TEntity GetById(Guid id);
        IQueryable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
