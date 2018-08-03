using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Modelo.Domain.Interfaces.ReadOnly;
using Modelo.Infra.Data.Oracle.Context;

namespace Modelo.Infra.Data.Oracle.Repository.ReadOnly
{
    public class RepositoryReadOnly<TEntity> : IRepositoryReadOnly<TEntity> where TEntity : class
    {
        protected readonly ModeloContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public RepositoryReadOnly(ModeloContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
