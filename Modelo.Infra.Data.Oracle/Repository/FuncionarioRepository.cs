using Modelo.Domain.Interfaces;
using Modelo.Domain.Models;
using Modelo.Infra.Data.Oracle.Context;

namespace Modelo.Infra.Data.Oracle.Repository
{
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(ModeloContext context)
            : base(context)
        {

        }
    }
}
