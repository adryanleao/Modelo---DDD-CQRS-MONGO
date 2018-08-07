using MediatR;
using Modelo.Domain.Core.Bus.Denormalize;
using Modelo.Domain.Core.Commands;
using Modelo.Domain.Core.Events;
using System.Threading.Tasks;

namespace Modelo.Infra.CrossCutting.Bus
{
    public sealed class InMemoryBusDenormalize : IMediatorHandlerDenormalize
    {
        private readonly IMediator _mediator;

        public InMemoryBusDenormalize(IMediator mediator)
        {_mediator = mediator;
        }

        public Task SendDenormalize<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }
    }
}
