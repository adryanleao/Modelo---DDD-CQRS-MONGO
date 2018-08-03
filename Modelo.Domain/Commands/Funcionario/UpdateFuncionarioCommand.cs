

using Modelo.Domain.Validations.Funcionario;
using System;

namespace Modelo.Domain.Commands.Funcionario
{
    public class UpdateFuncionarioCommand : FuncionarioCommand
    {
        public UpdateFuncionarioCommand(Guid id, string nome, string email, DateTime dataAniversario)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataAniversario = dataAniversario;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateFuncionarioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
