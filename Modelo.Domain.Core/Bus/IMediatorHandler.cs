using Modelo.Domain.Core.Commands;
using Modelo.Domain.Core.Events;
using System.Threading.Tasks;

namespace Modelo.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
