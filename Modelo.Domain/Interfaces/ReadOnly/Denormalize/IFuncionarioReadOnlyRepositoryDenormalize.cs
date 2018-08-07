using Modelo.Domain.Models;

namespace Modelo.Domain.Interfaces.ReadOnly
{
    public interface IFuncionarioReadOnlyRepositoryDenormalize : IRepositoryReadOnlyDenormalize<Funcionario>
    {
        Funcionario GetByEmail(string email);
    }
}
