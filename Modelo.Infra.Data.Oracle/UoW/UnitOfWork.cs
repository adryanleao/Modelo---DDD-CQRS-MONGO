using Modelo.Domain.Interfaces;
using Modelo.Infra.Data.Oracle.Context;

namespace Modelo.Infra.Data.Oracle.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ModeloContext _context;

        public UnitOfWork(ModeloContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
