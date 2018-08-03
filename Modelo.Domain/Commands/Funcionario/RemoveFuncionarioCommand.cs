using Modelo.Domain.Validations.Funcionario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Domain.Commands.Funcionario
{
    public class RemoveFuncionarioCommand : FuncionarioCommand
    {
        public RemoveFuncionarioCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveFuncionarioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
