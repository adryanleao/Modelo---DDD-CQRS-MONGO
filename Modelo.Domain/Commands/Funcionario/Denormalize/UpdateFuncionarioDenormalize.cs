using System;

namespace Modelo.Domain.Commands.Funcionario.Denormalize
{
    public class UpdateFuncionarioDenormalize : FuncionarioDenormalize
    {
        public UpdateFuncionarioDenormalize(Guid id, string nome, string email, DateTime dataAniversario)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataAniversario = dataAniversario;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
