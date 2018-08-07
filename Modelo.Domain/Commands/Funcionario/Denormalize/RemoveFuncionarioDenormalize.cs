using System;

namespace Modelo.Domain.Commands.Funcionario.Denormalize
{
    public class RemoveFuncionarioDenormalize : FuncionarioDenormalize
    {
        public RemoveFuncionarioDenormalize(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
        public override bool IsValid()
        {
            return true;
        }
    }
}
