using Modelo.Domain.Core.Notifications;
using Modelo.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Modelo.Domain.Commands.Funcionario.Denormalize;
using Modelo.Domain.Core.Bus.Denormalize;
using Modelo.Domain.Models;
using Modelo.Domain.Interfaces.Denormalize;

namespace Modelo.Domain.CommandHandlers.Denormalize
{
    public class FuncionarioDenormalizeHandler : DenormalizeHandler,
        IRequestHandler<RegisterNewFuncionarioDenormalize>,
        IRequestHandler<UpdateFuncionarioDenormalize>,
        IRequestHandler<RemoveFuncionarioDenormalize>
    {
        private readonly IFuncionarioRepositoryDenormalize _funcionarioRepository;
        private readonly IMediatorHandlerDenormalize BusDenormalize;

        public FuncionarioDenormalizeHandler(IFuncionarioRepositoryDenormalize funcionarioRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandlerDenormalize busDenormalize,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, busDenormalize, notifications)
        {
            _funcionarioRepository = funcionarioRepository;
            BusDenormalize = busDenormalize;
        }

        public Task Handle(RegisterNewFuncionarioDenormalize message, CancellationToken cancellationToken)
        {
            _funcionarioRepository.Add(new Funcionario(message.Id, message.Nome, message.Email, message.DataAniversario));
            return Task.CompletedTask;
        }

        public Task Handle(UpdateFuncionarioDenormalize message, CancellationToken cancellationToken)
        {
            _funcionarioRepository.Update(new Funcionario(message.Id, message.Nome, message.Email, message.DataAniversario));
            return Task.CompletedTask;
        }

        public Task Handle(RemoveFuncionarioDenormalize message, CancellationToken cancellationToken)
        {
            _funcionarioRepository.Remove(message.Id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _funcionarioRepository.Dispose();
        }
    }
}
