using Modelo.Domain.Validations.Funcionario;
using System;

namespace Modelo.Domain.Commands.Funcionario
{
    public class RegisterNewFuncionarioCommand : FuncionarioCommand
    {
        public RegisterNewFuncionarioCommand(string nome, string email, DateTime dataAniversario)
        {
            Nome = nome;
            Email = email;
            DataAniversario = dataAniversario;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewFuncionarioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
