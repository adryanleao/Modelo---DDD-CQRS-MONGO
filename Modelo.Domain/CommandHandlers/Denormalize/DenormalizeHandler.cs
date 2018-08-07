using MediatR;
using Modelo.Domain.Core.Bus.Denormalize;
using Modelo.Domain.Core.Notifications;
using Modelo.Domain.Interfaces;

namespace Modelo.Domain.CommandHandlers.Denormalize
{
    public class DenormalizeHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMediatorHandlerDenormalize _busDenormalize;
        private readonly DomainNotificationHandler _notifications;

        public DenormalizeHandler(IUnitOfWork uow, IMediatorHandlerDenormalize busDenormalize, INotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _notifications = (DomainNotificationHandler)notifications;
            _busDenormalize = busDenormalize;
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications()) return false;
            if (_uow.Commit()) return true;

           // _busDenormalize.RaiseEvent(new DomainNotification("Commit", "Tivemos problemas ao salvar os dados."));
            return false;
        }
    }
}
