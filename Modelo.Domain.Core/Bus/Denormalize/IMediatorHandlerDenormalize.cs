using Modelo.Domain.Core.Commands;
using Modelo.Domain.Core.Events;
using System.Threading.Tasks;

namespace Modelo.Domain.Core.Bus.Denormalize
{
    public interface IMediatorHandlerDenormalize
    {
        Task SendDenormalize<T>(T command) where T : Command;
    }
}
