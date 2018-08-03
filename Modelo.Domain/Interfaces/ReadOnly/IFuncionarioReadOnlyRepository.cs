using Modelo.Domain.Models;

namespace Modelo.Domain.Interfaces.ReadOnly
{
    public interface IFuncionarioReadOnlyRepository : IRepositoryReadOnly<Funcionario>
    {
        Funcionario GetByEmail(string email);
    }
}
