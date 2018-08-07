using Infra.Data.Mongo.Context;
using Modelo.Domain.Interfaces.Denormalize;
using Modelo.Domain.Models;

namespace Infra.Data.Mongo.Repository
{
    public class FuncionarioRepositoryDenormalize : Repository<Funcionario>, IFuncionarioRepositoryDenormalize
    {
        public FuncionarioRepositoryDenormalize(MongoDbContext context)
            : base(context, "Funcionarios")
        {

        }
    }
}
