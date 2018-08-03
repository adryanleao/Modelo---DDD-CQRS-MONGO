using MediatR;
using Modelo.Domain.Events.Funcionario;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Modelo.Domain.EventHandlers.Funcioanario
{
    public class FuncionarioEventHandler :
        INotificationHandler<FuncionarioRegisteredEvent>,
        INotificationHandler<FuncionarioUpdatedEvent>,
        INotificationHandler<FuncionarioRemovedEvent>
    {
        public Task Handle(FuncionarioUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return Task.CompletedTask;
        }

        public Task Handle(FuncionarioRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail

            return Task.CompletedTask;
        }

        public Task Handle(FuncionarioRemovedEvent message, CancellationToken cancellationToken)
        {
            // Send some see you soon e-mail

            return Task.CompletedTask;
        }
    }
}
