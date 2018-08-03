using FluentValidation;
using Modelo.Domain.Commands.Funcionario;
using System;

namespace Modelo.Domain.Validations.Funcionario
{
    public abstract class FuncionarioValidation<T> : AbstractValidator<T> where T : FuncionarioCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Voce precisa preencher o nome.")
                .Length(2, 150).WithMessage("O nome deve ter entre 2 e 150 caracteres.");
        }

        protected void ValidateBirthDate()
        {
            RuleFor(c => c.DataAniversario)
                .NotEmpty()
                .Must(HaveMinimumAge)
                .WithMessage("O funcionario deve ter mais de 18 anos.");
        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected static bool HaveMinimumAge(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddYears(-18);
        }
    }
}
