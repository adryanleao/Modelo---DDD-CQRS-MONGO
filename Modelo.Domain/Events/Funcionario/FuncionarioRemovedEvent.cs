using Modelo.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Domain.Events.Funcionario
{
    public class FuncionarioRemovedEvent : Event
    {
        public FuncionarioRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
