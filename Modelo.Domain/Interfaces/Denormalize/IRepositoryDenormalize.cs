using System;
using System.Linq;

namespace Modelo.Domain.Interfaces.Denormalize
{
    public interface IRepositoryDenormalize<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
       // TEntity GetById(Guid id);
      //  IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(Guid id);
    }
}
