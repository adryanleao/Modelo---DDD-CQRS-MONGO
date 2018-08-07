using Modelo.Domain.Commands.Funcionario.Normalize;

namespace Modelo.Domain.Validations.Funcionario
{
    public class UpdateFuncionarioCommandValidation : FuncionarioValidation<UpdateFuncionarioCommand>
    {
        public UpdateFuncionarioCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidateBirthDate();
            ValidateEmail();
        }
    }
}
