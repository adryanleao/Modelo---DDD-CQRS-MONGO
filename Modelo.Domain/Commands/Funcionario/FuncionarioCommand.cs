using Modelo.Domain.Core.Commands;
using System;

namespace Modelo.Domain.Commands.Funcionario
{
    public abstract class FuncionarioCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Nome { get; protected set; }

        public string Email { get; protected set; }

        public DateTime DataAniversario { get; protected set; }
    }
}
