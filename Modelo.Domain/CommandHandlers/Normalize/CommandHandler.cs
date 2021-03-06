﻿using MediatR;
using Modelo.Domain.Core.Bus.Normalize;
using Modelo.Domain.Core.Commands;
using Modelo.Domain.Core.Notifications;
using Modelo.Domain.Interfaces;

namespace Modelo.Domain.CommandHandlers.Normalize
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMediatorHandlerNormalize _bus;
        private readonly DomainNotificationHandler _notifications;

        public CommandHandler(IUnitOfWork uow, IMediatorHandlerNormalize bus, INotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _notifications = (DomainNotificationHandler)notifications;
            _bus = bus;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications()) return false;
            if (_uow.Commit()) return true;

            _bus.RaiseEvent(new DomainNotification("Commit", "Tivemos problemas ao salvar os dados."));
            return false;
        }
    }
}
