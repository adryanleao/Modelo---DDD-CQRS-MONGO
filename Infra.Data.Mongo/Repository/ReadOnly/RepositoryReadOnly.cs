using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Infra.Data.Mongo.Context;
using Modelo.Domain.Core.Models;
using Modelo.Domain.Interfaces.ReadOnly;
using MongoDB.Driver;

namespace Infra.Data.Mongo.Repository
{
    public class RepositoryReadOnly<T> : IRepositoryReadOnlyDenormalize<T> where T : ModelBase
    {
        protected readonly MongoDbContext Db;
        protected readonly IMongoCollection<T> DbSet;

        public RepositoryReadOnly(MongoDbContext context, string nameColection)
        {
            Db = context;
            DbSet = Db.Database.GetCollection<T>(nameColection);
        }

        public void Dispose()
        {
            
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            var a = DbSet.AsQueryable<T>();
            return a;
        }

        public T GetById(Guid id)
        {
            return DbSet.Find(f => f.Id == id).FirstOrDefault();
        }
    }
}
