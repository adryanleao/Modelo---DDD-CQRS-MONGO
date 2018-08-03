using Modelo.Domain.Commands.Funcionario;
using Modelo.Domain.Core.Bus;
using Modelo.Domain.Core.Notifications;
using Modelo.Domain.Events.Funcionario;
using Modelo.Domain.Interfaces;
using Modelo.Domain.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Modelo.Domain.Interfaces.ReadOnly;

namespace Modelo.Domain.CommandHandlers
{
    public class FuncionarioCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewFuncionarioCommand>,
        IRequestHandler<UpdateFuncionarioCommand>,
        IRequestHandler<RemoveFuncionarioCommand>
    {
        private readonly IFuncionarioReadOnlyRepository _funcionarioReadOnlyRepository;
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IMediatorHandler Bus;

        public FuncionarioCommandHandler(IFuncionarioReadOnlyRepository funcionarioReadOnlyRepository,
                                      IFuncionarioRepository funcionarioRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _funcionarioReadOnlyRepository = funcionarioReadOnlyRepository;
            _funcionarioRepository = funcionarioRepository;
            Bus = bus;
        }

        public Task Handle(RegisterNewFuncionarioCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var funcionario = new Funcionario(Guid.NewGuid(), message.Nome, message.Email, message.DataAniversario);

            if (_funcionarioReadOnlyRepository.GetByEmail(funcionario.Email) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "Ja existe um funcionario com esse e-mail."));
                return Task.CompletedTask;
            }

            _funcionarioRepository.Add(funcionario);

            if (Commit())
            {
                Bus.RaiseEvent(new FuncionarioRegisteredEvent(funcionario.Id, funcionario.Nome, funcionario.Email, funcionario.DataAniversario));
            }

            return Task.CompletedTask;
        }

        public Task Handle(UpdateFuncionarioCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var funcionario = new Funcionario(message.Id, message.Nome, message.Email, message.DataAniversario);
            var existingFuncionario = _funcionarioReadOnlyRepository.GetByEmail(funcionario.Email);

            if (existingFuncionario != null && existingFuncionario.Id != funcionario.Id)
            {
                if (!existingFuncionario.Equals(funcionario))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "Ja existe um funcionario com esse e-mail."));
                    return Task.CompletedTask;
                }
            }

            _funcionarioRepository.Update(funcionario);

            if (Commit())
            {
                Bus.RaiseEvent(new FuncionarioUpdatedEvent(funcionario.Id, funcionario.Nome, funcionario.Email, funcionario.DataAniversario));
            }

            return Task.CompletedTask;
        }

        public Task Handle(RemoveFuncionarioCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            _funcionarioRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new FuncionarioRemovedEvent(message.Id));
            }

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _funcionarioRepository.Dispose();
        }
    }
}
