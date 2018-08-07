using System;
using Infra.Data.Mongo.Context;
using Modelo.Domain.Core.Models;
using Modelo.Domain.Interfaces.Denormalize;
using MongoDB.Driver;

namespace Infra.Data.Mongo.Repository
{
    public class Repository<T> : IRepositoryDenormalize<T> where T : ModelBase
    {
        protected readonly MongoDbContext Db;
        protected readonly IMongoCollection<T> DbSet;

        public Repository(MongoDbContext context, string nameColection)
        {
            Db = context;
            DbSet = Db.Database.GetCollection<T>(nameColection);
        }
        public void Add(T obj)
        {
            DbSet.InsertOne(obj);
        }

        public void Dispose()
        {
            
        }

        public void Remove(Guid id)
        {
            DbSet.DeleteOne(d => d.Id == id);
        }
        public void Update(T obj)
        {
            DbSet.ReplaceOne(d => d.Id == obj.Id, obj);
        }
    }
}
