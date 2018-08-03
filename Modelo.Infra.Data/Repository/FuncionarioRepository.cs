using Microsoft.EntityFrameworkCore;
using Modelo.Domain.Interfaces;
using Modelo.Domain.Models;
using Modelo.Infra.Data.Context;
using System.Linq;

namespace Modelo.Infra.Data.Repository
{
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(ModeloContext context)
            : base(context)
        {

        }
    }
}
