using Microsoft.EntityFrameworkCore;
using Modelo.Domain.Interfaces.ReadOnly;
using Modelo.Domain.Models;
using Modelo.Infra.Data.Context;
using System.Linq;

namespace Modelo.Infra.Data.Repository.ReadOnly
{
    public class FuncionarioReadOnlyRepository : RepositoryReadOnly<Funcionario>, IFuncionarioReadOnlyRepository
    {
        public FuncionarioReadOnlyRepository(ModeloContext context)
            : base(context)
        {

        }
        public Funcionario GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        }
    }
}
