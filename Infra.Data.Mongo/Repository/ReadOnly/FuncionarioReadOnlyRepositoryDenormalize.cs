using Infra.Data.Mongo.Context;
using Modelo.Domain.Interfaces.ReadOnly;
using Modelo.Domain.Models;
using MongoDB.Driver;

namespace Infra.Data.Mongo.Repository
{
    public class FuncionarioReadOnlyRepositoryDenormalize : RepositoryReadOnly<Funcionario>, IFuncionarioReadOnlyRepositoryDenormalize
    {
        public FuncionarioReadOnlyRepositoryDenormalize(MongoDbContext context)
            : base(context, "Funcionarios")
        {

        }
        public Funcionario GetByEmail(string email)
        {
            return DbSet.Find(f => f.Email == email).FirstOrDefault();
        }
    }
}
