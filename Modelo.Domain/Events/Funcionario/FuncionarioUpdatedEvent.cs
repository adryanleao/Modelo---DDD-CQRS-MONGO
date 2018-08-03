using Modelo.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Domain.Events.Funcionario
{
    public class FuncionarioUpdatedEvent : Event
    {
        public FuncionarioUpdatedEvent(Guid id, string nome, string email, DateTime dataAniversario)
        {
            Id = id;
            Name = nome;
            Email = email;
            DataAniversario = dataAniversario;
            AggregateId = id;
        }
        public Guid Id { get; set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public DateTime DataAniversario { get; private set; }
    }
}
