using MediatR;
using Modelo.Domain.Commands.Funcionario.Denormalize;
using Modelo.Domain.Core.Bus.Denormalize;
using Modelo.Domain.Events.Funcionario;
using System.Threading;
using System.Threading.Tasks;

namespace Modelo.Domain.EventHandlers.Funcioanario
{
    public class FuncionarioEventHandler :
        INotificationHandler<FuncionarioRegisteredEvent>,
        INotificationHandler<FuncionarioUpdatedEvent>,
        INotificationHandler<FuncionarioRemovedEvent>
    {
        private readonly IMediatorHandlerDenormalize BusDenormalize;

        public FuncionarioEventHandler(IMediatorHandlerDenormalize busDenormalize)
        {
            this.BusDenormalize = busDenormalize;
        }
        public Task Handle(FuncionarioUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Atualizar entidade no mongo
            var updateDenormalize = new UpdateFuncionarioDenormalize(message.Id,message.Name, message.Email, message.DataAniversario);
            BusDenormalize.SendDenormalize(updateDenormalize);
            return Task.CompletedTask;
        }

        public Task Handle(FuncionarioRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Adicionar entidade no mongo
            var registerDenormalize = new RegisterNewFuncionarioDenormalize(message.Id,message.Name, message.Email, message.DataAniversario);
            BusDenormalize.SendDenormalize(registerDenormalize);
            return Task.CompletedTask;
        }

        public Task Handle(FuncionarioRemovedEvent message, CancellationToken cancellationToken)
        {
            // Remover entidade no mongo
            var updateDenormalize = new RemoveFuncionarioDenormalize(message.Id);
            BusDenormalize.SendDenormalize(updateDenormalize);
            return Task.CompletedTask;
        }
    }
}
