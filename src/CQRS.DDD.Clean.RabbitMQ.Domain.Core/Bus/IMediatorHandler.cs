using Teste.BancoMaster.Domain.Core.Commands;
using Teste.BancoMaster.Domain.Core.Events;

namespace Teste.BancoMaster.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
