using MediatR;
using Modelo.Domain.Core.Bus.Normalize;
using Modelo.Domain.Core.Commands;
using Modelo.Domain.Core.Events;
using System.Threading.Tasks;

namespace Modelo.Infra.CrossCutting.Bus
{
    public sealed class InMemoryBusNormalize : IMediatorHandlerNormalize
    {
        private readonly IMediator _mediator;

        public InMemoryBusNormalize(IMediator mediator)
        {_mediator = mediator;
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            return _mediator.Publish(@event);
        }
    }
}
