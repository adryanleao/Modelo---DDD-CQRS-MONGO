using Modelo.Domain.Commands.Funcionario.Normalize;

namespace Modelo.Domain.Validations.Funcionario
{
    public class RegisterNewFuncionarioCommandValidation : FuncionarioValidation<RegisterNewFuncionarioCommand>
    {
        public RegisterNewFuncionarioCommandValidation()
        {
            ValidateName();
            ValidateBirthDate();
            ValidateEmail();
        }
    }
}
