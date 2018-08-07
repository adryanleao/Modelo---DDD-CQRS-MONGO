using Modelo.Domain.Commands.Funcionario.Normalize;

namespace Modelo.Domain.Validations.Funcionario
{
    public class RemoveFuncionarioCommandValidation : FuncionarioValidation<RemoveFuncionarioCommand>
    {
        public RemoveFuncionarioCommandValidation()
        {
            ValidateId();
        }
    }
}
